using System;
using System.Collections.Generic;

namespace FunWithEnumerables
{
    class Program
    {
        public static void DemonstrateSimpleEnumerables()
        {
            var myEnumerable = new FibonacciEnumerable();

            //using (var enumerator = myEnumerable.GetEnumerator())
            //{
            //    while (enumerator.MoveNext())
            //    {
            //        Console.WriteLine(enumerator.Current);
            //        return;
            //    }
            //}

            var counter = 0;

            foreach (var item in myEnumerable)
            {
                counter++;
                Console.WriteLine(item);
                if (counter > 20) break;
            }

        }

        public static void DemonstrateEnumeratingLists()
        {
            var list = new List<int>
            {
                2, 4, 6, 8, 10, 20
            };

            foreach (var item in list)
            {
                Console.WriteLine(item);
                if (item == 10) list.Add(30);
            }
        }

        static void Main(string[] args)
        {
            DemonstrateEnumeratingLists();

        }
    }
}
