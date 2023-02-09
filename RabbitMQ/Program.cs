using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace RabbitMQ
{
    class Program
    {
        Connection obj = new Connection();
        public void createExchangeNQueue(string Ename,string Qname)
        {
            RabbitMQ.Client.IModel model = obj.RMQ_Connect();
           try
           {
               Console.WriteLine("Creating Exchange...");               
               model.ExchangeDeclare(Ename, ExchangeType.Direct, true, false, null);
               System.Threading.Thread.Sleep(2000);
               Console.WriteLine("Exchange With Same Name Found Or Was Created At " + System.DateTime.Now);
               Console.WriteLine("Creating Queue...");
               model.QueueDeclare(Qname, true, false, false, null);
               System.Threading.Thread.Sleep(2000);
               Console.WriteLine("Queue With Same Name Found Or Was Created At " + System.DateTime.Now);
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
           }        
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            Console.Write("Enter Exchange Name : ");
            string Ename = Console.ReadLine();
            Console.Write("Enter Queue Name : ");
            string Qname = Console.ReadLine();
            obj.createExchangeNQueue(Ename, Qname);
            RMQ_Binding binding = new RMQ_Binding(Ename,Qname);
            binding.bind_QE();
            RMQ_Publish_MSGS publish = new RMQ_Publish_MSGS();
            Console.Write("Enter Your Message Here : ");
            string MSG = Console.ReadLine();
            publish.Send_MSG(Ename,MSG);
            Console.ReadKey();
        }
    }
}
