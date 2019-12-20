using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            sample sampleObj = new sample();
            sampleObj.Add(10, 11);
            sampleObj.Add("Add", " Values");
            Console.ReadLine();
        }
    }

    class sample
    {
        public void Add(int x, int y)
        {
            Console.WriteLine("x + y = {0}", x + y);
        }

        public void Add(string x, string y)
        {
            Console.WriteLine("x + y = {0}", x + y);
        }

        //public string Add(string x, string y) // Just changing the return type throws error, as already same name method exists
        //{
        //    Console.WriteLine("x + y = {0}", x + y);
        //}
    }
}
