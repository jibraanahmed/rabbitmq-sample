using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace RabbitMQ_Fanout.Classes
{
    class Connection
    {
        private readonly string UserName = "guest";
        private readonly string Password = "guest";
        private readonly string HostName = "localhost";

        public RabbitMQ.Client.IModel RMQ_Connect()
        {
            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
            {
                UserName = this.UserName,
                Password = this.Password,
                HostName = this.HostName
            };

            var connection = connectionFactory.CreateConnection();
            var MODEL = connection.CreateModel();
            return MODEL;
        }
    }
}
