using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Homework1Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSkip();
            TestSkipUntil();
            TestAlternate();
        }

        public static void TestSkip()
        {
            var list = new List<int> { 1, 3, 5, 7, 9, 11 };

            var result = list.Skip(4);
            var success = result.Assert(9, 11);
            Console.WriteLine($"Skip test result: { success}");
        }

        public static void TestSkipUntil()
        {
            var list = new List<int> { 1, 6, 10, 4, 9, 12 };
            
            var result = list.SkipUntil(i => i > 9);
            var success = result.Assert(10, 4, 9, 12);

            Console.WriteLine($"SkipUntil test result: {success}");
        }

        public static void TestAlternate()
        {
            var list1 = new List<int> { 1, 2, 3, 4, 5 };
            var list2 = new List<int> { 10, 20, 30 };

            var result = list1.Alternate(list2);
            var success = result.Assert(1, 10, 2, 20, 3, 30, 4);

            Console.WriteLine($"Alternate test result: {success}");
        }
    }
}
