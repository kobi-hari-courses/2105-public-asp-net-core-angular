using System;
using System.Collections.Generic;
using System.Linq;

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
                var option = _mainMenu.GetUserSelection(false);
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
            var all = Api.GetAllManufacturers();

            foreach (var item in all)
            {
                $"{item.Name,-35} {item.Year,-5} {item.Country}".Print(ConsoleColor.Cyan);
            }
        }

        private static void ListCarsOfManufacturer()
        {
            var manfuacturers = Api
                .GetAllManufacturers()
                .Select(m => m.Name);

            var selected = manfuacturers.GetUserSelection();

            var cars = Api.GetCarsOfManufacturer(selected.option);

            foreach (var car in cars)
            {
                $"{car.Make,-30} {car.Model,-30} {car.Cylinders}".Print(ConsoleColor.Cyan);
            }
        }


        private static void ListNumberOfCarsPErManufacturer()
        {
            var res = Api.GetManufacturerNumberOfCars();

            foreach (var item in res)
            {
                $"{item.manufacturer,-35} {item.numberOfCars}".Print(ConsoleColor.Cyan);
            }
        }


        private static void ListBestCarsOfManufacturers()
        {
            var countries = Api.GetAllCountries();

            var selected = countries.GetUserSelection();

            var carGroups = Api.GetBestCarsOfManufacturersFrom(selected.option);

            foreach (var group in carGroups)
            {
                group.make.Print(ConsoleColor.Cyan);

                foreach (var car in group.cars)
                {
                    $"{car.Model,-30} {car.Year,-5}, {car.CombinedFe}".Print();
                }
            }
        }

        private static void ListGeneralHighlights()
        {
        }


    }
}
