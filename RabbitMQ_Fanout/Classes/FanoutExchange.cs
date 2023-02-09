using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ_Fanout.Classes
{
    class FanoutExchange
    {
        #region objects&data
        private Connection obj = null;
        private readonly string ExchangeName;
        private string[] queuesname;
        #endregion
        
        public FanoutExchange(string ExchangeName)
        {
            this.ExchangeName = ExchangeName;
        }
        private void createQueues()
        {
            Console.Write("How Many Queues You Need For The Fanout Exchange ? => ");
            int n = Convert.ToInt32(Console.ReadLine());
            queuesname = new string[n];
            int count = 0;
            obj = new Connection();
            var model = obj.RMQ_Connect();
            try
            {
                while (n != count)
                {             
                    Console.Write(count + 1 +" Queue Name : ");
                    string Qname = Console.ReadLine();
                    Console.WriteLine("Creating Queue...");
                    model.QueueDeclare(Qname, true, false, false, null);
                    System.Threading.Thread.Sleep(2000);
                    queuesname[count] = Qname;
                    Console.WriteLine("Queue With Same Name Found Or Was Created At " + System.DateTime.Now);
                    count++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ExecuteQueues()
        {
            createQueues();
        }
        public void create_FanoutExchange()
        {
            obj = new Connection();
            var model = obj.RMQ_Connect();
            try
            {
                Console.WriteLine("Creating Exchange...");
                model.ExchangeDeclare(ExchangeName, ExchangeType.Fanout, true, false, null);
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("Exchange With Same Name Found Or Was Created At " + System.DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Binding_QE()
        {
            var model = obj.RMQ_Connect();
            Thread.Sleep(500);
            Console.WriteLine("Binding Queue's With Fanout Exchange!");
            try
            {
                Thread.Sleep(1000);
                Console.WriteLine("Binding Above Queue's and Exchange!");
                for (int i = 0; i < queuesname.Length; i++)
			    {
                model.QueueBind(queuesname[i], ExchangeName, "WAR", null);
                System.Threading.Thread.Sleep(3000);
			    }   
                Console.WriteLine("Success...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
