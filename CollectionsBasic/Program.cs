using System;
using System.Collections.Generic;
using System.Collections;

namespace CollectionsBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5]; /* Fixed in size , but type safe only integer can be stored*/ /*If this need to be resized , 
                                   need to create new array of different size and copy the existing array values to it */
            /* Inserting/Deleting values from the middle of the Array is not possible*/
            //    Console.WriteLine(arr.Length);
            Array.Resize(ref arr, 10); /*internally creates new array and copies the values and destroys the old array */
            //    Console.WriteLine(arr.Length);
            /*Collections - available in System.Collections */
            /* Are of Non Generic type but auto resizable */
            /* ArrayList , Stack, Queue, HashList , LinkedList,SortedList Classes*/
            ArrayList AL = new ArrayList();
            Console.WriteLine(AL.Capacity);
            AL.Add(5); AL.Add("gowtham"); AL.Add(23.0000);
           // AL.Add(5); AL.Add("gowtham"); AL.Add(23.0000);
            AL.Insert(1, 100000); /* insert method to insert at any place in the list */
            AL.Remove(10000);/* remove method to remove any value from the list*/
            AL.RemoveAt(1);/* remove method to remove any value at specified index from the list*/
            Console.WriteLine(AL.Capacity);
              foreach (var item in AL)
               {
                   Console.Write(item + " ");
               }
              Console.WriteLine();
            Hashtable HT = new Hashtable(); /* Stores the values in a UserDefined Key/Values pairs */
            /*Even Array/ArrayList stores the values in Key (Index)/Value Pairs, but these keys(index values) are 
              predefined (0,1...,n-1) */
            Console.WriteLine("Hashtable Starts");
            HT.Add("EmpName", "Gowthaman");
            HT.Add("EmpId", 402994);
            HT.Add(1234, "30 / 10 / 1991");
            foreach (var keys in HT.Keys) /* Ht.Values diretly accesses and print values  */
            /* Ht.Keys gets the keys (just like index values but userdefined ) and can print associated values with it */
            /* HT has one more value associated with Keys we enter i.e., HashCode (an int value) which we dont have control over and 
             * based on that order only we will get the output displayed*/
            {
                Console.WriteLine(keys + ": " + HT[keys] + " ");
                Console.WriteLine(keys.GetHashCode());
                Console.WriteLine(HT[keys].GetHashCode());
            }

            /* To overcome the Type safety constraints(it accepts any type of value you try to add) in Collections, C# 2.0 MS
             Introduced Generics Concept - System.Collections.Generic*/
            /*Whenever you try to declare List- it asks for 'T' which is the type of the List (strongly typed list of objects) */
            List<int> Li = new List<int>(); /*It can add only integer values, throws error if we try to add other types*/
            //Li.Add("int");
            Li.Add(10);
            /*Other than this all the features available in Collections will be available in this Generic List as well */
            //Hashtable<int, string> Ht = new Hashtable<int, string>(); need to see equiv for Hashtable in Generic Collection*/ equivalent is Dictionary<TKey,TValue>

            //Genrics<int> genobj = new Genrics<int>();  /*Generics is introduced in C# 2.0*/
            Genrics genobj = new Genrics();
            Console.WriteLine(genobj.Add(10, 100));
            Console.WriteLine(genobj.Add<string>("string A","string B"));
            Console.WriteLine(genobj.Subtract(99, 100));
            Console.WriteLine(genobj.Add(1000, 11000));

            //Genrics<string> genobj1 = new Genrics<string>();
            //Console.WriteLine(genobj1.Add("Name +", "Gowtham"));
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Equal", "similar");
            //dict.Add("Equal", "same");
            /*dict.Add("Equal", "Absolute"); /*Same Key names throws error , saying already key exists- 
            need to check actual use of dictionary/ why it is named so? */           
            Console.WriteLine("Meanings of Equal");
            foreach (string item in dict.Keys)
            {
                if (item.Equals("Equal"))
                {
                    Console.WriteLine(dict[item]);
                } 
            } 
            
            Console.ReadLine();
        }

      
        
    }

    //class Genrics<T>
    //{
    //    public T Add(T a, T b)
    //    {
    //        // var v1 = a; /* not working */
    //        // var v2 = b;
    //        dynamic d1 = a;     /*Dynamic is introduced in c# 4.0 */
    //        dynamic d2 = b;
    //        return d1 + d2;
    //    }

    //    public T Subtract(T a, T b)
    //    {
    //        // var v1 = a; /* not working */
    //        // var v2 = b;
    //        dynamic d1 = a;
    //        dynamic d2 = b;
    //        if (d1 > d2)
    //            return d1 - d2;
    //        else
    //            return d2 - d1;
    //    }
    //}

    class Genrics
    {
        public T Add<T>(T a, T b)
        {
            // var v1 = a; /* not working */
            // var v2 = b;
            dynamic d1 = a;     /*Dynamic is introduced in c# 4.0 */
            dynamic d2 = b;
            return d1 + d2;
        }

        public T Subtract<T>(T a, T b)
        {
            // var v1 = a; /* not working */
            // var v2 = b;
            dynamic d1 = a;
            dynamic d2 = b;
            if (d1 > d2)
                return d1 - d2;
            else
                return d2 - d1;
        }
    }
}
