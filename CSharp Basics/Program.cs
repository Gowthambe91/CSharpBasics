using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CSharp_Basics
{
    class Program
    {
        public enum studentType { 
        Engineer = 12, Doctor, Arts, Science
        }
        static void Main(string[] args)
        {
            int ab=1;
            char ch='1';
            int cd=3;
            DateTime dt=new DateTime();
            dt=DateTime.Today;
            string filepath=@"c:\users\gowtham\documents\visual studio 2012\Projects\CSharp Basics\CSharp Basics\FileReports\sample.txt";
            string exampath = "~/FileReports/";

            Sample.sample(ref ch,out ab);
            Sample so=new Sample();
            so.Num = 11111;
            so.sample1();

            //FileStream file = new FileStream(filepath, FileMode.OpenOrCreate);
            //Console.WriteLine("{0},{1},{2},{3}",ch,ab,so.recursive(5),exampath);
            Console.WriteLine(studentType.Arts + " " + Convert.ToDouble(studentType.Arts));

            try
            {
                int y = 0;
                //if (y == 0)
                //{
                //    throw (new DivideByZeroExcep("Division cannot be done on value 0"));
                //    //new DivideByZeroException
                //}
                //int x = 5 / y;
               
            }
            catch (Exception d)
            {
                Console.WriteLine(d.Message);
                ;// If we throw exception, at some place we should catch it handle it.                
            }
            finally
            {
                Console.WriteLine("finally");
            }

            Console.ReadLine();
        }

        void test()
        {
            Console.WriteLine("adasdasda");
        }
    }

    class DivideByZeroExcep : ArithmeticException
    {
        public DivideByZeroExcep(string message) { }
    }
    class Sample
    {
        public Sample()
        {
            Console.WriteLine("Constructor Sample");
        }

        ~Sample()
        {
            Console.WriteLine("DEstructor called");
        }

        private int num;
        public int Num { get { return num; } set { num = value; } }
        public void sample1()
        {
            Console.WriteLine("{0}-sample void", num);
        }
        public static void sample(ref char ch,out int i)
        {
            ch = 'c';
            i = 10;
            Console.WriteLine("Sample static void");
        }

        public int recursive(int x)
        {
            if (x == 1 || x== 0 )
                return 1;
            return( x * recursive(x - 1));
        }

    }
}
