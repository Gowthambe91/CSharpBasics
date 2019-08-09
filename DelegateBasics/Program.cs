using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://msiyer.com/2015/03/10/understanding-delegates-in-csharp-for-beginners/ - good article to understand delegate's real world usage
// Delegate - a person designated to act for or representing someone
// Type safe pointers to function methods
namespace Delegates
{
    //Gave static - threw error - The modifier 'static' is not valid for this item
    public delegate int Addnumbers(int n1, int n2); // Delegates are user defined types like Classes,Structs etc, so these needs to be instantiated to be used in a program
    public delegate string SayHello(string name); // Declaration looks similar to a method but with a delegate word.
   

    public class Sample
    {
        public int Addnum(int num1, int num2)
        {
            return num1 + num2;
        }

        public string SayHello(string name)
        {
            return "Hello " + name;
        }
    }

    public class Employee // A class assume which is not owned by us and there is a logic which is hard coded need to be removed/modified enough to control it.
    {
        public delegate bool IsEligibleforPromotion(Employee emp); // Delegate to find Is eligible to Promote employees
        public string Name { get; set; }
        public double Salary { get; set; }
        public int YearsOfExp { get; set; }
        public static void IsPromotable(List<Employee> emp, IsEligibleforPromotion IsEligible) // Pass the delegate as parameter which references the logic method which finds eligible/not 
        {
            if (emp != null)
            {
                foreach (Employee employee in emp)
                {
                    // if (emp.YearsOfExp > 5) // Hard coded logic inside a class , if at all anytime consumer (who uses this class) needs a logic change will be under trouble.
                    if (IsEligible(employee)) // calling the method delegate
                        Console.WriteLine("Eligible");
                    else
                        Console.WriteLine("Not Eligible");
                }
            }
            else
                Console.WriteLine("Employee List is Empty");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Sample s = new Sample();
            //Instantiating the delegates
            Addnumbers Add = new Addnumbers(s.Addnum);//constructor clearly shows the signature of the target method to be given, if there are any discrepancy , it will throw compile error
            // shows its type safety
            SayHello Say = new SayHello(s.SayHello);// if i try to give Addnum method here (int method), immediately shows error.

            //IsEligibleforPromotion IsEligible = emp => emp.Salary >= 10000; // Delegate instantiation
            Employee.IsEligibleforPromotion IsEligible = new Employee.IsEligibleforPromotion(Program.IsEligibleforPromote); // Delegate instantiation

            List<Employee> emplist = new List<Employee>(); // To understand the delegate usage, how to make resuable code logic
            emplist.Add(new Employee { Name = "Mike", Salary = 1000, YearsOfExp = 4 });
            emplist.Add(new Employee { Name = "Mary", Salary = 11000, YearsOfExp = 5 });
            emplist.Add(new Employee { Name = "Matt", Salary = 10000, YearsOfExp = 6 });
            emplist.Add(new Employee { Name = "John", Salary = 8000, YearsOfExp = 5 });


            //Calling the methods via Delegates
            Console.WriteLine(Add.Invoke(10, 150)); // Even this way/below way we can call the methods via Delegates.
            Console.WriteLine(Add(10, 250));
            Console.WriteLine(Say("Gowthaman"));

            Employee.IsPromotable(emplist, IsEligible); // Calling the Method of consumed class which is out of our control

            Console.ReadLine();
        }

        //To have our own logic how to find the eligible employees
        public static bool IsEligibleforPromote(Employee emp)
        {
            if (emp.Salary >= 9000) // Salary logic , any time we can change the logic since its under our control.
                return true;
            else
                return false;
        }
    }
}
