using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroductionToLinq.Exercise2
{
    // Perform this exercises after studying 01-09

    [TestClass]
    public class ExerciseTest
    {
        [TestMethod]
        public void Test1()
        {
            // Find the name of the company with the largest number of orders that
            // is located in the city of "Buenos Aires" 
            
            // This is incorrect. Replace the right side with the correct query

            var companyName = Customers.CustomerList.Last().CompanyName;

            Assert.AreEqual("Cactus Comidas para llevar", companyName);
        }

        [TestMethod]
        public void Test2()
        {
            List<Customer> customers = Customers.CustomerList;

            // Representing an order as a tuple (CustomerID, OrderID, Total)
            // find all the orders whose Total is smaller than 20M

            // This is incorrect. Replace the right side with the correct query

            var orders = new[] { ("", 5, 1M) };

            var expected = new[]
            {
                ("CACTU", 10782, 12.50M),
                ("FRANS", 10807, 18.40M)
            };

            Assert.IsTrue(expected.SequenceEqual(orders));

        }
    }
}