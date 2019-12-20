using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    class Program
    {
        /*https://www.claudiobernasconi.ch/2013/07/22/when-to-use-ienumerable-icollection-ilist-and-list/*/
        static void Main(string[] args)
        {
            IEnumerable<int> enumerable = new List<int>() { 1, 2, 3, 4 };
            
            //enumerable.add() -- Add is not available in IEnumerable type
            IList<int> list = new List<int>();
            list.Add(11);
            list.Add(12);
            list.Add(13);
            list.Add(14);
            
            Console.WriteLine(Enumerable.Max(enumerable));
            Console.WriteLine(enumerable.Max());
            Console.WriteLine(list.Max());
            Console.ReadLine();
        }
    }
}
