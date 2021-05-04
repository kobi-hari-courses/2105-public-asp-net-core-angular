using System;
using System.Linq;
using System.Threading;

namespace IntroductionToLinq
{
    class AggregatorsSample
    {
        public void Run()
        {
            Count();
            CountWithCondition();
            Sum();
            SumProperty();
            Min();
            MinProperty();
            AverageOfProjection();
            Aggregate();
            AggregateWithSeed();
        }

        // This sample uses Count to get the number of unique factors of 300.

        private static void Count()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };

            int factors = factorsOf300.Count();

            Console.WriteLine($"There are {factors} factors of 300.");
        }

        // This sample uses Count to get the number of odd ints in the array.
        
        private static void CountWithCondition()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int oddNumbers = numbers.Count(n => n % 2 == 1);

            Console.WriteLine("There are {0} odd numbers in the list.", oddNumbers);
        }

        // This sample uses Sum to get the total of the numbers in an array.

        private static void Sum()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            double numSum = numbers.Sum();

            Console.WriteLine($"The sum of the numbers is {numSum}");
        }

        // This sample uses Sum to get the total number of characters of all words in the array.

        private static void SumProperty()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            double totalChars = words.Sum(w => w.Length);

            Console.WriteLine($"There are a total of {totalChars} characters in these words.");
        }

        // This sample uses Min to get the lowest number in an array.

        private static void Min()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int minNum = numbers.Min();

            Console.WriteLine($"The minimum number is {minNum}");
        }

        // This sample uses Min to get the length of the shortest word in an array.

        private static void MinProperty()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            int shortestWord = words.Min(w => w.Length);

            Console.WriteLine($"The shortest word is {shortestWord} characters long.");
        }

        // This sample uses Average to get the average length of the words in the array.

        private static void AverageOfProjection()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            double averageLength = words.Average(w => w.Length);

            Console.WriteLine($"The average word length is {averageLength} characters.");
        }

        // This sample uses Aggregate to create a running product on the array that calculates the total product of all elements.

        private static void Aggregate()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            double product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);

            Console.WriteLine($"Total product of all numbers: {product}");
        }

        // This sample uses Aggregate to create a running account balance that subtracts each withdrawal from the initial balance of 100, as long as the balance never drops below 0.

        private static void AggregateWithSeed()
        {
            double startBalance = 100.0;

            int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };

            double endBalance =
                attemptedWithdrawals.Aggregate(
                    startBalance,
                    (balance, nextWithdrawal) =>
                        ((nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance));

            Console.WriteLine($"Ending balance: {endBalance}");
        }
    }
}