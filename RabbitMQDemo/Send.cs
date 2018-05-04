using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQDemo
{
    public class Send
    {
        public void SendMsg(string message)
        {
            //这里的端口及用户名都是默认的，可以直接设置一个hostname=“localhost”其他的不用配置
            var factory = new ConnectionFactory() { HostName = "192.168.1.15",Port=5672,UserName= "guest",Password= "guest" };
            //创建一个连接，连接到服务器：
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //创建一个名称为hello的消息队列
                    //durable:队列持久化，为了防止RabbitMQ在退出或者crash等异常情况下数据不会丢失，可以设置durable为true
                    //exclusive：排他队列,只对首次声明它的连接（Connection）可见，不允许其他连接访问，在连接断开的时候自动删除，无论是否设置了持久化
                    //autoDelete：自动删除，如果该队列已经没有消费者时，该队列会被自动删除。这种队列适用于临时队列。
                    channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    //channel.BasicConsume("hello", autoAck: true);

                    var props = channel.CreateBasicProperties();
                    //消息持久化，若启用durable则该属性启用
                    props.Persistent = true;
                    //封装消息主体
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "testExchange", routingKey: "hello2", basicProperties: props, body: body);
                    Console.WriteLine(" 发送消息{0}", message);
                }
            }
        }
    }
}
