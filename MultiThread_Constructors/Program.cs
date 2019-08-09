using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// There are 4 constructors for Thread class imp ones are ThreadStart start,ParameterizedThreadStart Start
namespace MultiThread_Constructors
{
    public delegate void SumOfNumbers(int sum);// This is delegate declaration to have a callback method to retrieve data from Thread function
    class Program
    {
        static void Test()
        {
            
            for (int i = 1; i < 20; i++)
            {
                Console.WriteLine("Test :" + i);
            }

            Console.WriteLine("Thread 1 exits");
        }

        static void Test(object max) //initially tried passing int, but the delegate does not match as it accepts only object type parameter. 
        {
            int num = Convert.ToInt32(max);
            for (int i = 1; i < num; i++)
            {
                Console.WriteLine("Test :" + i);
            }

            Console.WriteLine("Parameterized Thread exits");
        }

        static void Main(string[] args)
        {
            
            SumOfNumbers sumdelegate = new SumOfNumbers(PrintSum);
            //ThreadStart TsObj = new ThreadStart(Test1);//ThreadStart is a delegate whose signature is void and takes no parameters, Since Test1 is 
            // of Same type it can be assigned, different ways of instantiating ThreadStart follows;
            //ThreadStart TsObj = Test1;
            //ThreadStart TsObj = delegate() { Test1(); }; // Anonymous method way of instantiation, generally of unnamed methods directly logic will be given
            ThreadStart TsObj = () => Test(); // Lambda Operator way, more simplified version
            Thread T1 = new Thread(TsObj);// One of the constructors of Thread class takes ThreadStart obj
            T1.Start();
            ParameterizedThreadStart PsObj = new ParameterizedThreadStart(Test);// Parameter should be object type
            Thread T2 = new Thread(PsObj);
            T2.Start(25); //Since it is object , this is not type safe, need to see how to make it type safe.
            //To make it type safe, encapsulate the Test method in a Helper class and pass the value to be passed in the constructor and call the
            //Test method using ThreadStart delegate. see below example
            HelperforTypeSafe HsObj = new HelperforTypeSafe(7, sumdelegate);// only int can be passed as its constructor demands integer value. TYPE SAFE!. 
            // + Added a delegate parameter to call the call back method.
            TsObj = new ThreadStart(HsObj.TestParameterized);
            Thread T3 = new Thread(TsObj);
            T3.Start();
            //Thread T4 = new Thread(PrintSum1);
            T1.Join(); T2.Join(); T3.Join();
            Console.WriteLine("Main Thread Exits");
            Console.ReadLine();
        }

        public static void PrintSum(int sum) // call back method to print the data from thread function
        {
            Console.WriteLine("Sum of numbers :" + sum);
        }

        public static int PrintSum1(int sum) // call back method to print the data from thread function
        {
            //Console.WriteLine("Sum of numbers :" + sum);
            return 1;
        }
    }

    class HelperforTypeSafe
    {
        int _num;
        SumOfNumbers _callbackmethod;
        public HelperforTypeSafe(int max, SumOfNumbers callback)
        {
            this._num = max;
            this._callbackmethod = callback;
        }

        public void TestParameterized() // If it is static method , to access non static field '_num' need to create a object for class
        {
            int _sum = 0;
            for (int i = 1; i < _num; i++)
            {
                _sum = _sum + i;
                //Console.WriteLine("TestParameterized :" + i);
            }

            if (_callbackmethod != null)
            {
                _callbackmethod.Invoke(_sum);
            }
            //Console.WriteLine("TestParameterized Parameterized Thread exits");
        }
    }
}
