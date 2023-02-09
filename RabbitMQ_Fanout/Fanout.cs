using RabbitMQ_Fanout.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ_Fanout
{
    class Fanout
    {
        static void Main(string[] args)
        {
            NecessaryRequirements obj = new NecessaryRequirements();
            obj.InitNecessaryObjectsAndSettings();
            Console.ReadKey();
        }
    }
}
