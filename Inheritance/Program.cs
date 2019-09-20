using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee();
            fullTimeEmployee.FirstName = "Full time";
            fullTimeEmployee.LastName = "Employee";

            fullTimeEmployee.printFullName();

            //PartTimeEmployee partTimeEmployee = new PartTimeEmployee();//it calls the derived class sepcific member
            
            Employee partTimeEmployee = new PartTimeEmployee();/* Base class variable referencing instance of child class, 
                                                                * calls the hidden base class member*/
            partTimeEmployee.FirstName = "Part time";
            partTimeEmployee.LastName = "Employee";

            partTimeEmployee.printFullName();/* Calls the member specific to this class when Derived class referencing derived class
                                              instance, when base class variable reference instance of child class - will call
                                              hidden method of base class -- see above*/

            fullTimeEmployee.printFirstName();//Should call the base class method, since not overriden/hidden
            partTimeEmployee.printFirstName();//Should call the overriden member from child class

            Console.ReadKey();
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void printFullName()/*Common Implementation of this parent class, can also be defined in child class for its specific
                                    implementation*/
        {
            Console.WriteLine(FirstName + " " + LastName);
        }

        public virtual void printFirstName() /*using virtual keyword we can override this method several derived classes, 
                                              * if not derived will have the same parent implementation*/
        {
            Console.WriteLine(FirstName + " from Parent Class");
        }
    }

    public class FullTimeEmployee : Employee /*FulltimeEmployee and PartTimeEmployee are specialised classes since it has both
                                              parent class - Employee feature as well as its own features*/
    {
        public float YearlySalary { get; set; }// Specific to FullTimeEmployee class
    }

    public class PartTimeEmployee : Employee
    {
        public float HourlyRate { get; set; }

        public new void printFullName() /*Specific definition for this part time employee - child class which hides the base class member, can use 'new' keyword to hide it
                                         intentionally*/
        {
            Console.WriteLine(FirstName + " " + LastName + " - Contractor");
        }

        public override void printFirstName()
        {
            //base.printFirstName();//like a typecase object calls printFirstName method
            Console.WriteLine(FirstName + " from Part time employee");
        }
    }
}
