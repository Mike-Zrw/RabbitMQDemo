using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQDemo
{
    public class RpcPub
    {
        public async Task<string> SendMsg(string message)
        {
            ConnectionFactory factory = RabbitMQHelper.ConFactory;
            //创建一个连接，连接到服务器：
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //定义一个临时的队列，用来接收返回的消息
                    string replyQueueName = channel.QueueDeclare().QueueName;
                    var consumer = new QueueingConsumer(channel);
                    //监听该临时队列，自动act消息
                    channel.BasicConsume(queue: replyQueueName, autoAck: true, consumer: consumer);


                    string corrId = Guid.NewGuid().ToString();
                    var props = channel.CreateBasicProperties();
                    //定义ReplyTo让服务端知道返回消息给哪个路由
                    props.ReplyTo = replyQueueName;
                    //定义CorrelationId作为消息的唯一关联ID
                    props.CorrelationId = corrId;

                    var messageBytes = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "", routingKey: "rpc_queue", basicProperties: props, body: messageBytes);
                    Task<string> result = new Task<string>(() =>
                    {
                        while (true)
                        {
                            string replystr = string.Empty;
                            consumer.GetResult((args) =>
                            {
                                if (args.BasicProperties.CorrelationId == corrId)
                                {
                                    replystr = Encoding.UTF8.GetString(args.Body);
                                }
                            });
                            if (replystr != string.Empty)
                                return replystr;
                        }
                    });
                    result.Start();
                    return await result;
                }
            }
        }
    }


    public class RpcConsumer : IDisposable
    {

        private ConnectionFactory factory = RabbitMQHelper.ConFactory;
        private IConnection connection;
        public void ReceiveMsg(Action<string> callback)
        {
            if (connection == null || !connection.IsOpen)
                connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: "rpc_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.BasicQos(0, 5, false);
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, arg) =>
            {
                var props = arg.BasicProperties;
                var replyProps = channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;
                callback($"接收到消息：{Encoding.UTF8.GetString(arg.Body)}");
                Thread.Sleep(2000);
                var responseBytes = Encoding.UTF8.GetBytes($"成功接收你的消息：{ Encoding.UTF8.GetString(arg.Body)}");
                channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
                channel.BasicAck(deliveryTag: arg.DeliveryTag, multiple: false);
            };
            channel.BasicConsume(queue: "rpc_queue", autoAck: false, consumer: consumer);
        }
        public void Dispose()
        {
            if (connection != null && connection.IsOpen)
                connection.Dispose();
        }

    }
}
