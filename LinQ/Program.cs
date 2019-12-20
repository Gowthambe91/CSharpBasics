using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstNumbers = new List<int>() { 1, 2, 3, 5, 6, 7, 8, 9, 11, 15, 22 };
            int secondMax1 = lstNumbers.OrderByDescending(x => x).Skip(1).FirstOrDefault();
            int secondMax2 = lstNumbers.OrderByDescending(x => x).Take(2).LastOrDefault();

            int secondMax3 = lstNumbers.OrderByDescending(x => x).TakeWhile(x => x > 10).LastOrDefault();
            Console.ReadLine();
        }
    }
}
