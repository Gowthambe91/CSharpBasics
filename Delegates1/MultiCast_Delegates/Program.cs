using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCast_Delegates // MultiCast delegates references to multiple methods of same signature
{
    class Program
    {
        delegate void MultiCastDelegate();
        static void Main(string[] args)
        {
            //MultiCastDelegate del1 = new MultiCastDelegate(SampleDelegateOne);
            //MultiCastDelegate del2 = new MultiCastDelegate(SampleDelegateTwo);
            //MultiCastDelegate del3 = new MultiCastDelegate(SampleDelegateThree);
            //MultiCastDelegate del4 = del1 + del2 + del3; // del4 is now multicasted , '+' used to register a method to a delegate 
                                                         // if we call del4 will invoke all the methods
            // if need to de-register a method '-' sign can be used.

            //Another way to make del4 multicast
            MultiCastDelegate del4 = SampleDelegateOne;
            del4 += SampleDelegateThree;
            del4 += SampleDelegateTwo; // These all methods will be there in list named  "Invokation List" and will execute in the order we assign;
            del4(); /* But when using MultiCastDelegates need to make sure the calling method is of 'void' type , because if we call return type methods the 
                     * the returned values gets overridden, that applicables for out parameter methods as well*/

            Console.ReadLine();
        }

        public static void SampleDelegateOne()
        {
            Console.WriteLine("SampleDelegateOne");
        }

        public static void SampleDelegateTwo()
        {
            Console.WriteLine("SampleDelegateTwo");
        }

        public static void SampleDelegateThree()
        {
            Console.WriteLine("SampleDelegateThree");
        }
    }
}
