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
            Console.WriteLine("{0},{1},{2},{3}",ch,ab,so.recursive(5),exampath);

            try
            {
                int y = 0;
                int x = 5 / y;
            }
            catch (Exception d)
            {
                //Console.WriteLine(d.Message);
                throw (new DivideByZeroException(d.Message));
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }

        void test()
        {
            Console.WriteLine("adasdasda");
        }
    }

    class DivideByZeroExcep : ApplicationException
    {
        public DivideByZeroExcep()
        {
            Console.WriteLine("Exception found");
        }
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
