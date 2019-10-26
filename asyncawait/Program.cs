using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//// https://www.youtube.com/watch?v=6_GTdR0gBVE

namespace asyncawait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");
            var worker = new Worker();
            worker.DoWork();

            while (!worker.Iscomplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }

    internal class Worker
    {

        public bool Iscomplete { get; internal set; }
   
        public Worker()
        {


        }

        internal async void DoWork()
        {
            this.Iscomplete = false;

            Console.WriteLine("doing Work");

            await LongOperation();

            this.Iscomplete = true;
        }

        private Task LongOperation()
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("working");
                Thread.Sleep(2000);

            });
        }
    }
}
