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

            var companyName = Customers.CustomerList
                .Where(c => c.City.Contains("Buenos Aires"))
                .OrderByDescending(c => c.Orders.Length)
                .Select(c => c.CompanyName)
                .First();


            Assert.AreEqual("Cactus Comidas para llevar", companyName);
        }

        [TestMethod]
        public void Test2()
        {
            var customers = Customers.CustomerList;

            // Representing an order as a tuple (CustomerID, OrderID, Total)
            // find all the orders whose Total is smaller than 20M

            var orders = customers.SelectMany(
                    c => c.Orders,
                    (c, o) => new { c, o })
                .Where(t => t.o.Total < 20.00M)
                .Select(t => (t.c.CustomerID, t.o.OrderID, t.o.Total)).ToArray();

            var expected = new[]
            {
                ("CACTU", 10782, 12.50M),
                ("FRANS", 10807, 18.40M)
            };

            Assert.IsTrue(expected.SequenceEqual(orders));
        }
    }
}