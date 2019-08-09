using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class
{
    
    public class Class1 : AbstractClass
    {
        //public abstract void display();
        //{
        //    Console.WriteLine("display");
        //}

        public override void abstractdisplay()
        {
            Console.WriteLine("abstractdisplay from derived class1 overriden");
        }

        public void display1()
        {
            Console.WriteLine("display1");
        }

        public override void abstractdisplay1()
        {
            Console.WriteLine("abstractdisplay1 from dervived class1 overridden");
        }
    }

    public abstract class AbstractClass
    {
        public abstract void abstractdisplay();
        //{
        //    Console.WriteLine("display");
        //}

        public virtual void abstractdisplay1()
        {
            Console.WriteLine("abstractdisplay1 from Base Class");
        }
    }

    public class Class2 : Class1
    {
        ////public void abstractdisplay1()
        ////{
        ////    Console.WriteLine("abstractdisplay1 from derived class2");
        ////}
    }

    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass class1 = new Class1();
            AbstractClass class2 = new Class2();

            //class1.display();
            //class1.display1();

            class1.abstractdisplay();
            class1.abstractdisplay1();

            class2.abstractdisplay();
            class2.abstractdisplay1();

            Console.ReadLine();
        }
    }
}
