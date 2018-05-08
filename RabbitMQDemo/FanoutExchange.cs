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
    /// <summary>
    /// 采用Fanout交换机进行消息发送和接收
    /// 忽略路由键
    /// 用一个临时的队列和交换机监听消息
    /// </summary>
    public class LogFanoutPub
    {
        public void SendMsg(string message)
        {
            ConnectionFactory factory = RabbitMQHelper.ConFactory;
            //创建一个连接，连接到服务器：
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var props = channel.CreateBasicProperties();
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "logs", routingKey: "info", basicProperties: props, body: body);
                    channel.BasicPublish(exchange: "logs", routingKey: "error", basicProperties: props, body: body);
                    Console.WriteLine("发送消息{0}", message);
                }
            }
        }
    }


    public class LogFanoutConsumer : IDisposable
    {
        private ConnectionFactory factory = RabbitMQHelper.ConFactory;
        private IConnection connection;
        public void ReceiveMsg(Action<string> callback)
        {
            if (connection == null || !connection.IsOpen)
                connection = factory.CreateConnection();
            IModel _channel = connection.CreateModel();
            _channel.ExchangeDeclare("logs", ExchangeType.Fanout, false,true);
            _channel.QueueDeclare(queue: "log1", durable: false, exclusive: false, autoDelete: true, arguments: null);
			//即使绑定了warn的路由键，仍然会接收到所有发送到logs的消息
            _channel.QueueBind("log1", "logs", "warn");
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                callback($"log1Write.message:{ea.RoutingKey}:{message}");
                //模拟消息处理需要两秒
                Thread.Sleep(2000);
                _channel.BasicAck(ea.DeliveryTag, false);
                this.Dispose();
            };
            string result = _channel.BasicConsume(queue: "log1", autoAck: false, consumer: consumer);
        }
        public void Dispose()
        {
            if (connection != null && connection.IsOpen)
                connection.Dispose();
        }
    }
}
