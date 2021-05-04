using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToLinq
{
    class PartitionSample
    {
        public void Run()
        {
            Take();
            Skip();
            TakeWhile();
            SkipWhile();
        }

        // This sample uses Take to get only the first 3 elements of the array.

        private static void Take()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var first3Numbers = numbers.Take(3);

            Console.WriteLine("First 3 numbers:");
            foreach (var n in first3Numbers)
            {
                Console.WriteLine(n);
            }
        }

        // This sample uses Skip to get all but the first 4 elements of the array.

        private static void Skip()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var allButFirst4Numbers = numbers.Skip(4);

            Console.WriteLine("All but first 4 numbers:");
            foreach (var n in allButFirst4Numbers)
            {
                Console.WriteLine(n);
            }
        }

        // This sample uses TakeWhile to return elements starting from the beginning of the array
        // until a number is hit that is not less than 6.

        private static void TakeWhile()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

            Console.WriteLine("First numbers less than 6:");
            foreach (var num in firstNumbersLessThan6)
            {
                Console.WriteLine(num);
            }
        }

        // This sample uses SkipWhile to get the elements of the array
        // starting from the first element divisible by 3.

        private void SkipWhile()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var laterNumbers = numbers.SkipWhile((n, index) => n >= index);

            Console.WriteLine("All elements starting from first element less than its position:");
            foreach (var n in laterNumbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}