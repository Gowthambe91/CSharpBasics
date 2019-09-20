using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowException
{
    class Program
    {
        static void Main(string[] args)
        {
            student std = new student(); //when student std = null, it was not even hitting print student method
            try
            {
                std.printStudent(std); //
            }
            catch (Exception ex) //when throw exception occurs, it catches the message passed from throw statement.
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
    public class student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public void printStudent(student std)
        {
            if (std != null) //just to check if throw works
                throw new NullReferenceException("Student object is null"); /*Throw keyword helps in raising exceptions manually*/
            Console.WriteLine(std.Name);
        }
    }
}
