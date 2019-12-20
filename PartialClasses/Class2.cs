using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClasses
{
    partial class Sample1
    {
        public string Name { get; set; }

        public void SetName()
        {
            Console.WriteLine("Enter Name: ");
            Name = Console.ReadLine();
        }
    }
}
