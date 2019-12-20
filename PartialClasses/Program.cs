using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClasses //All the partial class definition Should be under the same namespace to work correctly
{
    class Program
    {
        static void Main(string[] args)
        {
            Sample1 sample1 = new Sample1();
            sample1.enterId();
            sample1.SetName();
            Console.WriteLine("Entered ID : {0}", sample1.ID);
            Console.WriteLine("Entered Name : {0}", sample1.Name);
            Console.ReadLine();
        }
    }

    partial class Sample1
    {
        public int ID { get; set; }
    }

    partial class Sample1
    {
        public void enterId()
        {
            Console.WriteLine("Enter ID: ");
            ID = Convert.ToInt32(Console.ReadLine());            
        }
    }
}
