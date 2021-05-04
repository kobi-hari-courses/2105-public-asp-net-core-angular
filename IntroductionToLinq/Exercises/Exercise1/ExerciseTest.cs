using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroductionToLinq.Exercise1
{
    // Perform this exercises after studying 01-04

    [TestClass]
    public class ExerciseTest
    {
        [TestMethod]
        public void TestSelect()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsPlusOne = numbers.MySelect<int, int> (n => n + 1);

            int sum = numsPlusOne.MySum();

            Assert.AreEqual(55, sum);
        }

        [TestMethod]
        public void TestSelectMany()
        {
            var customers = Customers.CustomerList;

            var orders = customers
                .MySelectMany(c => c.Orders);

            int count = orders.MyCount();

            Assert.AreEqual(830, count);
        }
    }
}