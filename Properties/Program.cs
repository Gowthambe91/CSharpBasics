using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            propertytest pt = new propertytest();
           // pt.Num = 10;
            pt.NUM1 = 1000;
            pt.display();
            propertytest.x = 10000;
            propertytest.staticmethodinNonStaticClass();
            Console.ReadLine();
        }
    }

    class propertytest
    {
        public propertytest()
        {
            NestedClass nc = new NestedClass();
            nc.display();
        }
        private int num;
        public static int x;
        public int NUM1 { get { return num; } set { num = value; } }// when this set / get explicitly set assigns the value correctly
       // public int Num { get; set; }
        public void display()
        {
            Console.WriteLine(num); // this always results '0', with auto implemented properties
        }

        public static void staticmethodinNonStaticClass()
        {
            x = 12000;
            Console.WriteLine("staticmethodinNonStaticClass {0}",x);
        }
    }

    class NestedClass
    {
        public NestedClass()
        {
            Console.WriteLine("Nested Class Instantiated from Property Class");
        }

        public void display()
        {
            Console.WriteLine("Display from Nested Class");
        }

        public void dataAccess()
        {
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                DataSet ds = new DataSet();
                da.Update(ds);
            }
        }

    }
}
