using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToLinq
{
    class OrderingSample
    {
        public void Run()
        {
            OrderBy();
            OrderByDescending();
            OrderByProperty();
            OrderByThenBy();
        }

        // This sample uses OrderBy to sort a list of words alphabetically.

        private static void OrderBy()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            var sortedWords = words.OrderBy(word => word);

            Console.WriteLine("The sorted list of words:");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }

        // This sample uses OrderByDescending to sort a list of words in reverse alphabetical order.

        private static void OrderByDescending()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords = words.OrderByDescending(word => word);

            Console.WriteLine("The sorted list of words:");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }

        // This sample uses orderby to sort a list of words by length.

        private static void OrderByProperty()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords = words.OrderBy(word => word.Length);

            Console.WriteLine("The sorted list of words (by length):");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }

        // This sample uses OrderBy and ThenBy to sort a list of digits,
        // first by length of their name, and then alphabetically by the name itself.

        private static void OrderByThenBy()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits = digits
                .OrderBy(digit => digit.Length)
                .ThenBy(digit => digit);

            Console.WriteLine("Sorted digits:");
            foreach (var d in sortedDigits)
            {
                Console.WriteLine(d);
            }
        }
    }
}
