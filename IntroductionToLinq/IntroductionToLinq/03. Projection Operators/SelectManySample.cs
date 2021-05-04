using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToLinq
{
    class SelectManySample
    {
        public void Run()
        {
            FlattenSequence();
            SelectFromMultipleSequences();
        }

        // This sample uses SelectMany to return all orders of all customers 

        private static void FlattenSequence()
        {
            var customers = Customers.CustomerList;

            var allOrders = customers
                .SelectMany(c => c.Orders);

            foreach (var order in allOrders)
            {
                Console.WriteLine(order.OrderID);
            }
        }

        // This sample uses an overload of SelectMany to return a sequence of orders
        // with information about the customer of the order

        private static void SelectFromMultipleSequences()
        {
            List<Customer> customers = Customers.CustomerList;

            var orders = customers.SelectMany(
                    c => c.Orders,
                    (c, o) => new { c, o })
                .Select(customerOrders => (
                    customerOrders.c.CustomerID, 
                    customerOrders.o.OrderID, 
                    customerOrders.o.Total));

            foreach (var order in orders)
            {
                Console.WriteLine($"Customer: {order.CustomerID}, Order: {order.OrderID}, Total value: {order.Total}");
            }
        }
    }
}