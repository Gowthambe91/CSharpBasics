using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace ThreadPriority
{

    class ThreadPerformance
    {
        static long Count1 = 0, Count2 = 0;
        static void Incrementer1()
        {
            for (long i = 0; i < 100000000; i++)
            {
                Count1++;
            }
            Console.WriteLine(Count1);
        }

        static void Incrementer2()
        {
            for (long i = 0; i < 100000000; i++)
            {
                Count2++;
            }
            Console.WriteLine(Count2);
        }

        static void Main()
        {
            Stopwatch S1 = new Stopwatch(); // To capture the time taken - [System.Diagnostics]
            S1.Start();
            Incrementer1();// Calling the Method by Single threaded model and capturing the time taken from Stop Watch
            Incrementer2();
            S1.Stop();

            Stopwatch S2 = new Stopwatch();
            Thread T1 = new Thread(Incrementer1); // Calling the method via multi threaded model
            Thread T2 = new Thread(Incrementer2);
            S2.Start();
            T1.Start();
            T2.Start();
            S2.Stop();
            T1.Join(); T2.Join();
            Console.WriteLine("Time Taken to execute the methods by Single Threaded Model: " + S1.ElapsedMilliseconds);// From result we see Single threaded model(3341ms) takes way higher time than Multi threaded(1ms).
            Console.WriteLine("Time Taken to execute the methods by Multi Threaded Model: " + S2.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }
}
