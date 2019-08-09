using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/*MultiTasking - 
 Nowadays Operating Systems helps in performing MultiTasking in our Desktops/Laptops, Since it has 
 included MultiThreading in it.
 
 Basically- Every Program/Application we run in our Computer has a process involved with it and which is actually 
 running the Application (Word,Excel,Outlook,VS,SQL etc.,).
 
 Every Process has atleast one thread in it which internally helps in running the App. Also, it can have multiple
 threads associated with it to facilitate the multitasking for an application.
 
 When it comes to our App(Program) in VS, each program we run has default one thread associated (Main Thread), 
 facilitating the running of Application. It is known as Single Threaded Model. This Single Thread will execute 
 each logic/method in our code sequentially/one by one which may cause delay of executing the next method if the 
 current method's execution gets delayed if it involves DB response/some time taking process.
 */
namespace MultiThreadingBasics
{
    class Program
    {
        static void Test1()
        {
            for (int i = 1; i < 20; i++)
            {
                Console.WriteLine("Test1 :" + i);
            }

            Console.WriteLine("Thread 1 exits");
        }

        static void Test2()
        {
            Console.WriteLine("Thread 2 is going to sleep :" + DateTime.Now);
            Thread.Sleep(5000); /*Static Method - Suspends the Thread for the Specified time milliseconds/timespan, which ultimately waits the Test3() method since thread is suspended 
                                    for certain time in Test2() method */
            /* To Avoid this unnecessary time delay, program can have Multiple Threads to call the different
             * methods (simultaneous) which are time taking, since we already know a process can have multiple threads inside it,
             * OS will allocate time for each thread (time sharing) to execute logics and that time allocation is not
             * in our control as its from OS.*/
            /* MultiThreading helps in Maximum Utilization of CPU resources */
            /* When it is called by Seprate thread(T2), only T2 will be suspended for 15 sec, other threads will share the CPU resources and keeps doing their Tasks, so a delay in 
             * one method does not affect the application performance , other methods will complete their task on time , thus does Maximum Utilization of CPU resources.!*/
            Console.WriteLine("Thread 2 woke up:" + DateTime.Now);
            for (int i = 1; i < 20; i++)
            {
                Console.WriteLine("Test2 :" + i);
            }

            Console.WriteLine("Thread 2 exits");
        }

        static void Test3()
        {
            for (int i = 1; i < 20; i++)
            {
                Console.WriteLine("Test3 :" + i);
            }

            Console.WriteLine("Thread 3 exits");
        }
        static void Main(string[] args)
        {
            //Include System.Threading NameSpace
            Thread t = Thread.CurrentThread; // Initially Name is empty
            t.Name = "Main Thread"; //Setting simply a name

            Console.WriteLine("CurrentThread Name is :" + t.Name);
            Console.WriteLine("CurrentThread Name is :" + Thread.CurrentThread.Name);
            Console.WriteLine("CurrentThread Priority is :" + t.Priority);
            //t.Abort(); // At this point Main Closes and below lines are not executing
            Console.WriteLine("CurrentThread ThreadState is :" + t.ThreadState);
            Console.WriteLine("CurrentThread IsAlive is :" + t.IsAlive);
            Console.WriteLine("CurrentThread ExecutionContext is :" + t.ExecutionContext);
            Console.WriteLine("CurrentThread CurrentCulture is :" + t.CurrentCulture);
            Console.WriteLine("CurrentThread CurrentUICulture is :" + t.CurrentUICulture);

            // Test1(); Test2(); Test3(); //Static methods call to understand the single threaded model execution and need for MultiThreading.

            Thread T1 = new Thread(Test1); //Call the methods through different Threads to understand the Time Sharing of Multi Threads
            //   It can also be called similar to below which is going to be internally performed */
            // *if we call it this way as above.*/
            Thread T2 = new Thread(Test2);// will not call the method until we start the Thread by T2.Start();
            Thread T3 = new Thread(Test3);
            //T1 = new Thread(Test2); // Tried assigning two methods to a thread but it does not work, overrides the already assigned method.
            T1.Start(); //T2.Start(); T3.Start(); // This will start the Thread to start the execution of the method and each thread Share the CPU resources allocated by CPU and 
            // executes the method simultaneously, not parallely since if CPU allots 2 sec for a thread T1 executes for 2 sec , control shifts to 
            //T2 for 2 sec and then T3 , then again T1 for 2 sec,T2, T3 it continues., how much ever work can be completed the T1 will do shifts the
            //control to next thread and goes on;
            T1.Join(); //T2.Join(3000); T3.Join(); //see below desc, if timespan is given Main thread which joins will wait until mentioned time span and gets exited, else wait until
                                                    // the Thread (T1,T2 or T3 gets exited)
            Console.WriteLine("Thread Main exits"); //Currently Main Thread's task is to create T1,T2,T3 threads and start them and immediately when CPU shares its time it will get
            // exited. But we should not allow Main Thread to go exit until all threads complete its task and exits. For that we need to make use of Join() Method of Thread Class.
            Console.ReadLine();
        }
    }
}
