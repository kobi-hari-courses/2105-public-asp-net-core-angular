using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroductionToLinq.Exercise3
{
    // Perform this exercises after studying 01-10

    [TestClass]
    public class ExerciseTest
    {
        [TestMethod]
        public void Test1()
        {
            List<Product> products = Products.ProductList;

            // A product group is a tuple containing (string, int)
            // where the string is a product category and the int is the number of products
            // in the category.

            // Find all the product groups in which the number of products is larger than 11
            // and the category starts with the letter C.

            // This is incorrect. Replace the right side with the correct query

            var productGroups = new[] { ("", 5) };

            var expected = new[]
            {
                ("Condiments", 12), ("Confections", 13)
            };

            Assert.IsTrue(expected.SequenceEqual(productGroups));
        }
    }
}