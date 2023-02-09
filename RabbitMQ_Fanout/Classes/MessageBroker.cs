using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ_Fanout.Classes
{
    class MessageBroker : DefaultBasicConsumer
    {
        private Connection obj = null;
        private byte[] buffer;
        private string message,exchange;
        private RabbitMQ.Client.IModel model = null;
        
        public MessageBroker(string message,string exchange)
        {
            obj = new Connection();
            model = obj.RMQ_Connect();
            this.exchange = exchange;
            this.message = message;
            buffer = new byte[message.Length];
        }
        
        private RabbitMQ.Client.IBasicProperties BasicSettings()
        {
            var properties = model.CreateBasicProperties();
            properties.Persistent = false;
            return properties;
        }
        public void SendMsgs()
        {
            try
            {
                buffer = Encoding.Default.GetBytes(message);
                model.BasicPublish(exchange,"",true,BasicSettings(),buffer);
                Console.WriteLine("Message Sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
           
            Console.WriteLine("Exchange Name : " + exchange);
            string msgs = Encoding.UTF8.GetString(body);
            Console.WriteLine("Message => " + msgs);
            model.BasicAck(deliveryTag,true);
        }
    }
}
