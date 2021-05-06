using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1
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

        public static void ListAllManufacturers()
        {
            var all = DataReader
                .GetAllManufacturers()
                .OrderBy(m => m.Name);

                                ;
            foreach (var item in all)
            {
                $"{item.Name,-35} {item.Year,-5} {item.Country}".Print(ConsoleColor.Cyan);
            }
        }

        public static void ListVehiclesOfManufactureres()
        {
            var manufacturers = DataReader
                .GetAllManufacturers()
                .OrderBy(m => m.Name)
                .Select(m => m.Name);

            var selected = manufacturers.GetUserSelection();

            var cars = DataReader.GetAllCars()
                .Where(car => car.Make == selected.option)
                .OrderBy(car => car.Model)
                .ThenBy(car => car.Cylinders);

            foreach (var car in cars)
            {
                $"{car.Make,-30} {car.Model,-30} {car.Cylinders}".Print(ConsoleColor.Cyan);
            }
        }

        public static void NumberOfCarsPerManufacturer()
        {
            var all = DataReader
                .GetAllCars()
                .GroupBy(car => car.Make)
                .Select(group => (name: group.Key, count: group.Count()));

            foreach (var item in all)
            {
                $"{item.name,-35} {item.count}".Print(ConsoleColor.Cyan);
            }
        }

        public static void ListBestCarsOfManufacturers()
        {
            var countries = DataReader
                .GetAllManufacturers()
                .Select(m => m.Country)
                .Distinct();

            var selected = countries.GetUserSelection();

            var manufactuers = DataReader
                .GetAllManufacturers()
                .Where(m => m.Country == selected.option)
                .Select(m => m.Name)
                .ToHashSet();

            var carGroups = DataReader
                .GetAllCars()
                .Where(m => manufactuers.Contains(m.Make))
                .GroupBy(m => m.Make)
                .Select(group => (
                        make: group.Key,
                        cars: group.OrderByDescending(car => car.CombinedFe)
                                   .Take(3)));

            foreach (var group in carGroups)
            {
                group.make.Print(ConsoleColor.Cyan);
                foreach (var car in group.cars)
                {
                    $"{car.Model,-30} {car.Year,-5} {car.CombinedFe}".Print(ConsoleColor.White);
                }
            }

        }

        public static void ListGeneralHighlights()
        {
            var cars = DataReader.GetAllCars().ToList();
            var mfgs = DataReader.GetAllManufacturers().ToList();

            var carWithLowestConbinedFe = cars
                .OrderBy(c => c.CombinedFe)
                .First();

            var avgCityFe = cars.Average(c => c.CityFe);

            var numberOfCounters = mfgs
                .Select(m => m.Country)
                .Distinct()
                .Count();

            var mfgWithHighestAvarageCombinedFe = cars
                .GroupBy(car => car.Make)
                .Select(group => (make: group.Key, avg: group.Average(car => car.CombinedFe)))
                .OrderByDescending(pair => pair.avg)
                .First();

            Print($"Car with lowest combined FE: {carWithLowestConbinedFe.Make} {carWithLowestConbinedFe.Model}: {carWithLowestConbinedFe.CombinedFe}", ConsoleColor.White);
            Print($"Average City FE: {avgCityFe}", ConsoleColor.White);
            Print($"Number of different countries: {numberOfCounters}", ConsoleColor.White);
            Print($"Manufacturer with highest average combined FE: {mfgWithHighestAvarageCombinedFe.make} ({mfgWithHighestAvarageCombinedFe.avg})", ConsoleColor.White);

        }



        static void Main(string[] args)
        {
            while (true)
            {
                var option = GetUserSelectionFromMenu(() => PrintMainMenu());
                switch (option)
                {
                    case 1:
                        ListAllManufacturers();
                        break;
                    case 2:
                        ListVehiclesOfManufactureres();
                        break;
                    case 3:
                        NumberOfCarsPerManufacturer();
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
    }
}
