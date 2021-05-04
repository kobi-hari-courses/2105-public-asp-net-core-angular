using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace IntroductionToLinq
{
    class SelectSample
    {
        public void Run()
        {
            Transform();
            SelectProperty();
            ProjectToType();
            ProjectToAnonymousType();
            ProjectToTuple();
            SelectWithIndex();
        }

        // This sample uses select to produce a sequence of ints one higher than those in an existing array of ints.
        // It demonstrates how select can modify the input sequence.
       
        private static void Transform()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var numsPlusOne = numbers.Select(n => n + 1);

            foreach (var i in numsPlusOne)
            {
                Console.WriteLine(i);
            }
        }

        // This sample uses select to return a sequence of just the names of a list of products.

        private static void SelectProperty()
        {
            List<Product> products = Products.ProductList;

            var productNames = products.Select(p => p.ProductName);

            Console.WriteLine("Product Names:");

            foreach (var productName in productNames)
            {
                Console.WriteLine(productName);
            }
        }

        class ConvertedString
        {
            public string Upper { get; set; }
            public string Lower { get; set; }
        }

        // This sample uses select to produce a sequence of the uppercase and lowercase versions of each
        // word in the original array.
        // The items in the output sequence are of type ConvertedString

        private static void ProjectToType()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = words
                .Select(w => new ConvertedString { Upper = w.ToUpper(), Lower = w.ToLower() });

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
            }
        }

        // This sample is like ProjectToType but the items in the output sequence are anonymous types

        private static void ProjectToAnonymousType()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = words
                .Select(w => new {Upper = w.ToUpper(), Lower = w.ToLower()});

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
            }
        }

        // Beginning with C# 7, you can also project to tuples, using the following syntax.
        // The items in the output sequence are instances of System.ValueTuple
      
        private static void ProjectToTuple()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = words
                .Select(w => (Upper: w.ToUpper(), Lower: w.ToLower()));

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
            }
        }

        // This sample uses an indexed Select clause to determine if the value of ints in an array match
        // their position in the array.

        private static void SelectWithIndex()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsInPlace = numbers
                .Select((num, index) => (Num: num, InPlace: (num == index)));

            Console.WriteLine("Number: In-place?");
            
            foreach (var n in numsInPlace)
            {
                Console.WriteLine($"{n.Num}: {n.InPlace}");
            }
        }
    }
}
