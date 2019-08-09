using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodHidingUsingNew
{
    class MethodHiding
    {
        static void Main(string[] args)
        {
            Base B = new Base();
            Derived1 d1 = new Derived1();
            Derived2 d2 = new Derived2();

            B.MethodBase();
            d1.MethodBase();
            d2.MethodBase();
            derivedabstract da = new derivedabstract();
            da.MyProperty = 1000;
            da.display();
            Console.ReadLine();
        }
    }

    class Base
    {
        public void MethodBase()
        {
            Console.WriteLine("Base:MethodBase");
        }
    }

    class Derived1 : Base // Inherits Base and its object can call method base 
    {
        public new void MethodBase() // If hiding is intended, need to use 'new' keyword to seperate it from BAse class method
        {
            Console.WriteLine("Derived1:MethodBase"); // Now it's object is calling it's own method though there is method with same name is inherited
        }
    }

    class Derived2 : Derived1 // Inherits Derived1 and its object can call method base // After Base.MethodBase is hidden in Derived1, its calling Derived1's MethodBase
    {
        public new void MethodBase()
        {
            Console.WriteLine("Derived2:MethodBase");
        }
    }

    public abstract class abstractclass
    {
        protected abstract void method();
    }

    public class derivedabstract : abstractclass, ITest
    {

        public int MyProperty { get; set; }
        public derivedabstract()
        {
            method();
        }

        protected override void method()
        {
            Console.WriteLine("abstract in protected");
        }

        public void display()
        {            
            Console.WriteLine("ITest display {0}", MyProperty);
        }
    }

    public interface ITest
    {
        int MyProperty { get; set; }

        void display();
    }
}
