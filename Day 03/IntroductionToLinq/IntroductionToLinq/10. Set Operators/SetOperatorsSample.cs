using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToLinq
{
    class SetOperatorsSample
    {
        public void Run()
        {
            Distinct();
            Union();
            Intersect();
        }

        // This sample uses Distinct to remove duplicate elements in a sequence of factors of 300.

        private static void Distinct()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };

            var uniqueFactors = factorsOf300.Distinct();

            Console.WriteLine("Prime factors of 300:");
            foreach (var f in uniqueFactors)
            {
                Console.WriteLine(f);
            }
        }

        // This sample uses Union to create one sequence that contains the unique values
        // from both arrays.

        private static void Union()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var uniqueNumbers = numbersA.Union(numbersB);

            Console.WriteLine("Unique numbers from both arrays:");
            foreach (var n in uniqueNumbers)
            {
                Console.WriteLine(n);
            }
        }

        // This sample uses Intersect to create one sequence that contains the common values
        // shared by both arrays.

        private static void Intersect()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var commonNumbers = numbersA.Intersect(numbersB);

            Console.WriteLine("Common numbers shared by both arrays:");
            foreach (var n in commonNumbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}