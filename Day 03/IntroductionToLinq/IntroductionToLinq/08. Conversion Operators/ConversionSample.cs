using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToLinq
{
    class ConversionSample
    {
        public void Run()
        {
            ToArray();
            ToList();
            ToDictionary();
        }

        // This sample uses ToArray to immediately evaluate a sequence into an array.

        private static void ToArray()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var sortedDoubles = doubles.OrderByDescending(d => d);
            var doublesArray = sortedDoubles.ToArray();

            Console.WriteLine("Every other double from highest to lowest:");
            for (int d = 0; d < doublesArray.Length; d += 2)
            {
                Console.WriteLine(doublesArray[d]);
            }
        }

        // This sample uses ToList to immediately evaluate a sequence into a list.

        private static void ToList()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            var sortedWords = words.OrderBy(w => w);
            var wordList = sortedWords.ToList();

            Console.WriteLine("The sorted word list:");
            foreach (var w in wordList)
            {
                Console.WriteLine(w);
            }
        }

        // This sample uses ToDictionary to immediately evaluate a sequence
        // and a related key expression into a dictionary.

        private static void ToDictionary()
        {
            var scoreRecords = new[] { 
                new {Name = "Alice", Score = 50},
                new {Name = "Bob"  , Score = 40},
                new {Name = "Cathy", Score = 45}
            };

            var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);

            Console.WriteLine("Bob's score: {0}", scoreRecordsDict["Bob"]);
        }
    }
}
