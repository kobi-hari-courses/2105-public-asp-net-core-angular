using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunWithExtMethods
{
    class Program
    {
        static void ExtensionMethodSample()
        {
            //string s = StringHelper.PadRight(
            //               StringHelper.PadLeft(
            //                   StringHelper.Double("Hello"), 15, '+'), 20, '-');

            string s = "Hello"
                        .Double()
                        .PadLeft(15, '+')
                        .PadRight(20, '-');

            var list = new List<int> { 1, 3, 6, 10, 15, 21, 28 };
            var mult = list
                           .Limit(4)
                            .Product();

            Console.WriteLine(s);
            Console.WriteLine(mult);
        }


        static void Main(string[] args)
        {
            var e = 9.Multipliers().Limit(5);
            foreach (var item in e)
            {
                Console.WriteLine(item);
            }

            //var rows = 1.Multipliers().Limit(10);

            //foreach (var row in rows)
            //{
            //    var items = row.Multipliers().Limit(10);
            //    foreach (var item in items)
            //    {
            //        Console.Write($"{item,5}");
            //    }
            //    Console.WriteLine();
            //}

        }
    }
}
