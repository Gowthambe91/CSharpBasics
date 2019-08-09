using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreadLocking
{
    //Lock is used to block the loop for execution if its already in use by other thread.
    class Program
    {
        public void Test()
        {
            lock (this)
            {
                Console.Write("[CSharp is an ");
                Thread.Sleep(5000);
                Console.WriteLine("Objected Oriented Language");
            }
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            Thread T1 = new Thread(obj.Test);
            Thread T2 = new Thread(obj.Test);
            Thread T3 = new Thread(obj.Test);
            T1.Start(); T2.Start(); T3.Start(); // Simultaneously tries to access the Test method for execution
            Console.ReadLine();
        }
    }
}
