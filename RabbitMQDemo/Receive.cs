using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQDemo
{
    public class Receive : IDisposable
    {
        public static int _number;
        private static ConnectionFactory factory;
        private static IConnection connection;
        static Receive()
        {
            factory = new ConnectionFactory() { HostName = "localhost" };
        }
        public Receive()
        {
            _number++;
        }
        public void ReceiveMsg(Action<string> callback)
        {
            if(connection==null||!connection.IsOpen)
                connection = factory.CreateConnection();
            IModel _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            // 创建事件驱动的消费者
            var consumer = new EventingBasicConsumer(_channel); 
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                callback($"number:{_number}.message:{message}");
                //模拟消息处理需要两秒
                Thread.Sleep(2000);
                //显示发送ack确认接收并处理完成消息，只有在前面进行启用显示发送ack机制后才奏效。
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            //指定消费队列,autoAct是否自动确认
            string result = _channel.BasicConsume(queue: "hello", autoAck: false, consumer: consumer);

            //设置后当所有的channel都关闭了连接会自动关闭
            //connection.AutoClose = true;
        }
        public void Dispose()
        {
            if (connection != null && connection.IsOpen)
                connection.Dispose();
        }
    }
}
