using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    class Connection
    {
        private string UserName = "guest";
        private string Password = "guest";
        private string HostName = "localhost";

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
