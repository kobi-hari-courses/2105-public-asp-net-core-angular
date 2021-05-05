using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToLinq
{
    class WhereSample
    {
        public void Run()
        {
            WhereByValue();
            WhereByProperties();
            WhereByPosition();
        }

        // This sample uses where to find all elements of an array less than 5

        private static void WhereByValue()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums = numbers.Where(num => num < 5);

            Console.WriteLine("Numbers < 5:");

            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }

        // This sample uses where to find all products that are in stock and
        // cost more than 3.00 per unit.

        private static void WhereByProperties()
        {
            List<Product> products = Products.ProductList;

            var expensiveInStockProducts = products
                .Where(prod => prod.UnitsInStock > 0 && prod.UnitPrice > 3.00M);

            Console.WriteLine("In-stock products that cost more than 3.00:");
            
            foreach (var product in expensiveInStockProducts)
            {
                Console.WriteLine($"{product.ProductName} is in stock and costs more than 3.00.");
            }
        }

        // This sample demonstrates an indexed Where clause that returns digits whose name is shorter
        // than their value.

        private static void WhereByPosition()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Where((digit, index) => digit.Length < index);

            Console.WriteLine("Short digits:");

            foreach (var d in shortDigits)
            {
                Console.WriteLine($"The word {d} is shorter than its value.");
            }
        }
    }
}