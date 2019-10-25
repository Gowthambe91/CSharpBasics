using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class MultipleInheritanceConflict : interface1, interface2
    {
        /*
                public void display() //if i give public, calls work fine, but still confusion which interface method is getting called, Probably hiding the interface methods and calls it's own implementation
                {
                    Console.WriteLine("From display Method - interface1");
                }
                */
        void interface1.display() /*If public is not mentioned, compile time error stating should implement the interface method,
            so has to specify the interface name to call the particular method*/
        {
            Console.WriteLine("From display Method - interface1");
        }

        void interface2.display()
        {
            Console.WriteLine("From display Method - interface2");
        }

        public void testInterface1()
        {
            Console.WriteLine("From testInterface1 Method");
        }
    }

    interface interface1
    {
        void display();
        void testInterface1();
    }

    interface interface2
    {
        void display();
    }
}
