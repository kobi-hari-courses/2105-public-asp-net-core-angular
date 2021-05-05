using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToLinq
{
    class ElementOperatorsSample
    {
        public void Run()
        {
            First();
            FirstOrDefault();
        }

        // This sample uses First to find the first element in the array that starts with 'o'.

        private static void First()
        {
            List<Product> products = Products.ProductList;

            Product product12 = products
                .First(p => p.ProductID == 12);

            Console.WriteLine(product12);
        }

        // This sample uses FirstOrDefault to try to return the first element of the sequence,
        // unless there are no elements, in which case the default value for that type is returned.

        private static void FirstOrDefault()
        {
            int[] numbers = { };

            int firstNumOrDefault = numbers.FirstOrDefault();

            Console.WriteLine(firstNumOrDefault);
        }
    }
}