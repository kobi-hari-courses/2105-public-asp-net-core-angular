using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToLinq
{
    class GroupingSample
    {
        public void Run()
        {
            GroupBy();
        }

        // This sample demonstrates the use of GroupBy to
        // create buckets based on the remainder of an integer when dividing it by 5.

        private static void GroupBy()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            IEnumerable<(int Remainder, IGrouping<int, int> Numbers)> numberGroups = numbers
                .GroupBy(n => n % 5)
                .Select(g => (Remainder: g.Key, Numbers: g));

            foreach (var g in numberGroups)
            {
                Console.WriteLine($"Numbers with a remainder of {g.Remainder} when divided by 5:");
                foreach (var n in g.Numbers)
                {
                    Console.WriteLine(n);
                }
            }
        }
    }
}