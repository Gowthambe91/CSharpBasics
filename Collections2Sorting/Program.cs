using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections2Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 0, 7, 5, 2, 8, 4, 2, 9, 100, 10 };
            List<string> names = new List<string>() { "AA","AAAB", "A", "Gowthaman", "BAAAC", "ACD", "BAAAB", "1" };
            /*Sorting in Simple types (iint,string,char,double,float etc.,) are easy as these simple type classes inherits "IComparable" 
            class and implements the CompareTo method*/
            numbers.Sort();
            Console.WriteLine("Sorted in Ascending Order");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            //Reversing the order
            numbers.Reverse();
            Console.WriteLine("Sorted in Descending Order");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            names.Sort();
            Console.WriteLine("Sorted names in Ascending Order");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            names.Reverse();
            Console.WriteLine("Sorted names in Descending Order");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Students S1 = new Students() { StudId = 1010, StudName = "Gowthaman", Marks = 785.00f };
            Students S2 = new Students() { StudId = 1002, StudName = "Karthik", Marks = 845.00f };
            Students S3 = new Students() { StudId = 1030, StudName = "Sujai", Marks = 790.80f };

            List<Students> StudentsLst = new List<Students>() { S1, S2, S3 };
            StudentsLst.Sort(); /* Throws error since IComparable is not inherited by the Students Class */
            foreach (Students Stud in StudentsLst)
            {
                Console.WriteLine("Student ID: {0}\t Student Name:{1}\t Marks: {2}\t\t",Stud.StudId,Stud.StudName,Stud.Marks);
            }
            SortByName sortByName = new SortByName();
            StudentsLst.Sort(sortByName);
            Console.WriteLine("Sorted By Name");
            foreach (Students Stud in StudentsLst)
            {
                Console.WriteLine("Student ID: {0}\t Student Name:{1}\t Marks: {2}\t\t", Stud.StudId, Stud.StudName, Stud.Marks);
            }

        }
    }

    /* Useful when you dont own the class Students and its methods */
    class SortByName : IComparer<Students>
    {
        public int Compare(Students x, Students y)
        {
            return x.StudName.CompareTo(y.StudName);
        }
    }
    #region Students Class starts here
    class Students : IComparable<Students>
    {
        public int StudId { get; set; }
        public string StudName { get; set; }
        public float Marks { get; set; }

        public int CompareTo(Students other)
        {
            
        //    if (this.Marks > other.Marks)
        //        return 1;
        //    else if (this.Marks < other.Marks)
        //        return -1;
        //    else
        //        return 0;
            /* The above can be written in way as below as well; */
            return this.Marks.CompareTo(other.Marks);
        }
    }
#endregion Students Class ends here
}
