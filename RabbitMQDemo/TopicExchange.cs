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
    /// 采用Topic交换机进行消息发送和接收
    /// 忽略路由键
    /// 用一个临时的队列和交换机监听消息
    /// </summary>
    public class LogTopicPub
    {
        public void SendMsg(string message)
        {
            var factory = RabbitMQHelper.ConFactory;
            //创建一个连接，连接到服务器：
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var props = channel.CreateBasicProperties();
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "logs", routingKey: "info.animal.dog", basicProperties: props, body: body);
                    channel.BasicPublish(exchange: "logs", routingKey: "info.color.red", basicProperties: props, body: body);
                    channel.BasicPublish(exchange: "logs", routingKey: "info.color.blue", basicProperties: props, body: body);
                    channel.BasicPublish(exchange: "logs", routingKey: "warn.weather.rain", basicProperties: props, body: body);
                    channel.BasicPublish(exchange: "logs", routingKey: "error.product.detail", basicProperties: props, body: body);
                    Console.WriteLine("发送消息{0}", message);
                }
            }
        }
    }


    public class LogTopicConsumer : IDisposable
    {
        private ConnectionFactory factory = RabbitMQHelper.ConFactory;
        private IConnection connection;

        public void ReceiveMsg(Action<string> callback)
        {
            if (connection == null || !connection.IsOpen)
                connection = factory.CreateConnection();
            IModel _channel = connection.CreateModel();
            _channel.ExchangeDeclare("logs", ExchangeType.Topic, false, true);
            _channel.QueueDeclare(queue: "log1", durable: false, exclusive: false, autoDelete: true, arguments: null);

            //*匹配一个单词
            _channel.QueueBind("log1", "logs", "info.animal.*");
            //相当于direct
            _channel.QueueBind("log1", "logs", "info.color.red");
            //#匹配后面的所有内容不管几个.
            _channel.QueueBind("log1", "logs", "warn.#");
            //因为*只匹配一个单词，所以error.product.detail不会接收到
            _channel.QueueBind("log1", "logs", "error.*");
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                callback($"log1Write.message:{ea.RoutingKey}:{message}");
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
