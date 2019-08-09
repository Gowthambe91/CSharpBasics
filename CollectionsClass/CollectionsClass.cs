using System;
using System.Collections.Generic; /* intro in 4.0*/
using System.Linq;
using System.Collections; /* intro in 2.0 */

namespace CollectionsClass
{
    public class CollectionsClass
    {
        

    }
    class program
    {
        static void main()
        {
            int[] arr = new int[5]; /* Fixed in size , but type safe only integer can be stored*/ /*If this need to be resized , 
                                   need to create new array of different size and copy the existing array values to it */
            Console.WriteLine(arr.Length);
            Array.Resize(ref arr, 10);
            Console.WriteLine(arr.Length);
            /*Collections - available in System.Collections */
            /* Are of Non Generic type but auto resizable */
            /* ArrayList , Stack, Queue, HashList */
            ArrayList AL = new ArrayList();
            Console.WriteLine(arr.Length);
            //Console.WriteLine(ArrayList.);
        }
    }
}
