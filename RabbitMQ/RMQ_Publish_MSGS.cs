using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    class RMQ_Publish_MSGS
    {
        private Connection obj;
        public void Send_MSG(string exchange, string msg)
        {
            obj = new Connection();
            RabbitMQ.Client.IModel model = obj.RMQ_Connect();
            var properties = model.CreateBasicProperties();
            properties.Persistent = false;         
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(msg);
                model.BasicPublish(exchange, "test", true, properties, buffer);
                Console.WriteLine("Message Sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);   
            }    
        }
    }
}
