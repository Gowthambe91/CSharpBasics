using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPriority
{
    class Program
    {
        static long Count1 = 0, Count2 = 0;
        static void Incrementcount1()
        {
            while (true) // To simulate the long running / long task to do method, Indefinite loop
            {
                Count1++;
            }
        }
        static void Incrementcount2()
        {
            while (true)
            {
                Count2++;
            }
        }

        static void Main(string[] args)
        {
            Thread T1 = new Thread(Incrementcount1); //There are no priorities set explicitly, means default it will take Normal, so both gets
            Thread T2 = new Thread(Incrementcount2); // time allocated by CPU similar cycles , but thats still not under our control to predict.
            /* 5 priorities are there which can be assigned by ThreadPriority Enum (Lowest=0,BelowNormal,Normal,AboveNormal,Highest=4)*/
            T1.Start(); T2.Start();
            T1.Priority = System.Threading.ThreadPriority.Highest; //Now T1 will get more CPU cycles than T2 since T1 priority is highest, T2- lowest
            T2.Priority = System.Threading.ThreadPriority.Normal;
            Thread.Sleep(5000);// Main Thread to sleep for 5sec, to make the T1 & T2 to run for 5 sec before Abort.
            T1.Abort(); T2.Abort(); //Terminates the Thread
            T1.Join(); T2.Join(); //Main Thread waits until T1 and T2 gets exited
            Console.WriteLine("Incrementcount1 :" + Count1); //After setting the priority to highest , always T1 count1 value is > T2 Count 2
            Console.WriteLine("Incrementcount2 :" + Count2);
            Console.WriteLine("Main Thread exits");
            Console.ReadLine();
        }
    }
}
