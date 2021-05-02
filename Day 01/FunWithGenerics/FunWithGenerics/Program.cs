using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FunWithGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            var li = new List<int>();

            var al = new ArrayList();

            var hs = new Handler<string>();
            hs.Handle("Hello");

            var b1 = hs.WasHandled("Hello");
            var b2 = hs.WasHandled("World");

            int[] numbers = new int[]
            {
                21, 43, 18, 12, 53, 96
            };

            Color[] colors = new Color[]
            {
                Color.Red,
                Color.Black,
                Color.Green,
                Color.Blue
            };

            Person[] people = new Person[]
            {
                new Person {FirstName = "John", LastName = "Lennon" },
                new Person {FirstName = "Paul", LastName = "McCartney" },
                new Person {FirstName = "George", LastName = "Harrison" },
                new Person {FirstName = "Richard", LastName = "Starkey" }
            };

            Array.Sort(numbers, new UnitsDigitComparaer());
            var allNumbersWithCommas = string.Join(',', numbers);

            Console.WriteLine(allNumbersWithCommas);

            var smallestNumber = CollectionHelper.TheSmallestItemOf(numbers);
            // var smallestColor = CollectionHelper.TheSmallestItemOf<Color>(colors);
            var onePerson = CollectionHelper.TheSmallestItemOf(people);
        }
    }
}


