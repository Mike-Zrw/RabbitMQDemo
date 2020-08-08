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
    public class QueueingConsumer : DefaultBasicConsumer
    {
        private IModel _channel;
        private BasicDeliverEventArgs args = new BasicDeliverEventArgs();

        private AutoResetEvent argResetEvent = new AutoResetEvent(false);
        public QueueingConsumer(IModel channel)
        {
            _channel = channel;
        }
        public override void HandleBasicDeliver(string consumerTag,
           ulong deliveryTag,
           bool redelivered,
           string exchange,
           string routingKey,
           IBasicProperties properties,
           byte[] body)
        {
            args = new BasicDeliverEventArgs
            {
                ConsumerTag = consumerTag,
                DeliveryTag = deliveryTag,
                Redelivered = redelivered,
                Exchange = exchange,
                RoutingKey = routingKey,
                BasicProperties = properties,
                Body = body
            };
            argResetEvent.Set();
        }

        public void GetResult(Action<BasicDeliverEventArgs> callback)
        {
            argResetEvent.WaitOne();
            callback(args);
        }

    }

}
