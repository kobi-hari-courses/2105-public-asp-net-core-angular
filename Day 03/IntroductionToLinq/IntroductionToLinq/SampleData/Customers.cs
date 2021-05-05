using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace IntroductionToLinq
{
    public static class Customers
    {
        public static List<Customer> CustomerList { get; set; } = GetCustomerList();

        private static List<Customer> GetCustomerList()
        {
            var rootElement = XDocument.Parse(CustomerData.CustomersXml).Root;

            return rootElement?.Elements("customer")
                .Select(e => new Customer
                {
                    CustomerID = (string) e.Element("id"),
                    CompanyName = (string) e.Element("name"),
                    Address = (string) e.Element("address"),
                    City = (string) e.Element("city"),
                    Region = (string) e.Element("region"),
                    PostalCode = (string) e.Element("postalcode"),
                    Country = (string) e.Element("country"),
                    Phone = (string) e.Element("phone"),
                    Orders = (e.Elements("orders")
                        .Elements("order")
                        .Select(o => new Order
                        {
                            OrderID = (int) o.Element("id"),
                            OrderDate = (DateTime) o.Element("orderdate"),
                            Total = (decimal) o.Element("total")
                        })).ToArray()
                }).ToList();
        }
    }
}
