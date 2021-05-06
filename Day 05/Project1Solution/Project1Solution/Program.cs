using System;
using System.Collections.Generic;

namespace Project1Solution
{
    class Program
    {
        static List<string> _mainMenu = new List<string>
        {
             "List All Manufacturers",
             "List Vehicles of Manufacturer",
             "List Number of cars per Manufacturer",
             "List Best cars of each Manufacturer",
             "List General highlights"
        };

        static void Main(string[] args)
        {
            while(true)
            {
                var option = _mainMenu.GetUserSelection();
                switch(option.index)
                {
                    case 1:
                        ListAllManufacturers();
                        break;
                    case 2:
                        ListCarsOfManufacturer();
                        break;
                    case 3:
                        ListNumberOfCarsPErManufacturer();
                        break;
                    case 4:
                        ListBestCarsOfManufacturers();
                        break;
                    case 5:
                        ListGeneralHighlights();
                        break;
                }
            }
        }
        private static void ListAllManufacturers()
        {
            throw new NotImplementedException();
        }


        private static void ListGeneralHighlights()
        {
            throw new NotImplementedException();
        }

        private static void ListBestCarsOfManufacturers()
        {
            throw new NotImplementedException();
        }

        private static void ListNumberOfCarsPErManufacturer()
        {
            throw new NotImplementedException();
        }

        private static void ListCarsOfManufacturer()
        {
            throw new NotImplementedException();
        }
    }
}
