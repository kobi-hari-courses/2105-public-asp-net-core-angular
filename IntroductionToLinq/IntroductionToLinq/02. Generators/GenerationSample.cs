using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToLinq
{
    class GenerationSample
    {
        public void Run()
        {
            Range();
            Repeat();
        }

        // This sample uses Range to generates a sequence of integral numbers within a specified range.
      
        private static void Range()
        {
            var numbers = Enumerable.Range(0, 10);
          
            foreach (var n in numbers)
            {
                Console.WriteLine("The number {0}", n);
            }
        }

        // This sample uses Repeat to generates a sequence that contains one repeated value.
        
        private static void Repeat()
        {
            var numbers = Enumerable.Repeat(0, 10);

            foreach (var n in numbers)
            {
                Console.WriteLine("The number {0}", n);
            }
        }
    }
}