using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    class RMQ_Binding
    {
        private Connection obj;

        #region private
        string Ename;
        string Qname;
        string key;
        #endregion

        public RMQ_Binding(string Ename,string Qname)
        {
            obj = new Connection();
            this.Ename = Ename;
            this.Qname = Qname;
            key = "test";
        }
        public void bind_QE()
        {
            RabbitMQ.Client.IModel model = obj.RMQ_Connect();
            try
            {
                Console.WriteLine("Binding Above Queue and Exchange!" + "Key = " + key);
                model.QueueBind(Qname, Ename, key, null);
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
