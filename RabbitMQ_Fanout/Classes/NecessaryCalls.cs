using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ_Fanout.Classes
{
    class NecessaryCalls
    {
        FanoutExchange obj = null;
        MessageBroker msgbkr = null;
        Connection con = null;
        public void InitNecessaryObjectsAndSettings()
        {
            Console.Write("Enter Your Fanout Exchange Name Here: ");
            string name = Console.ReadLine();
            obj = new FanoutExchange(name);
            obj.ExecuteQueues();
            obj.create_FanoutExchange();
            obj.Binding_QE();
            System.Threading.Thread.Sleep(2000);
            Console.Write("Enter Your Message Here: ");
            string msg = Console.ReadLine();
            msgbkr = new MessageBroker(msg, name);
            msgbkr.SendMsgs();
            con = new Connection();
            var model = con.RMQ_Connect();
            model.BasicConsume("abc1", false, "NoTag", true, true, null, msgbkr);

        }
    }
}
