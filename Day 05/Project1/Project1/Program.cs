using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1
{
    class Program
    {
        public static void Print(string str, ConsoleColor color)
        {
            var tmp = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = tmp;
        }

        public static int PrintMainMenu()
        {
            Print("Please Select an option:", ConsoleColor.Green);
            Print("1. List All Manufacturers", ConsoleColor.Yellow);
            Print("2. List Vehicles of Manufacturer", ConsoleColor.Yellow);
            Print("3. List Number of cars per Manufacturer", ConsoleColor.Yellow);
            Print("4. List Best cars of each Manufacturer", ConsoleColor.Yellow);
            Print("5. List General highlights", ConsoleColor.Yellow);

            return 5;
        }

        public static int GetUserSelectionFromMenu(Func<int> menu)
        {
            var max = menu();

            while (true)
            {
                var choice = Console.ReadLine();
                if (int.TryParse(choice, out var option))
                {
                    if ((option >0) && (option <= max))
                    {
                        return option;
                    }

                    Print($"Please select an option between 1 and {max}", ConsoleColor.Red);
                }
                else
                {
                    Print("Please enter a number", ConsoleColor.Red);
                }
            }
        }

        public static string GetUserSelectionFromStrings(IEnumerable<string> options)
        {
            var all = options
                .OrderBy(m => m)
                .Select((m, index) => (name: m, index: index))
                .ToList();

            Func<int> menu = () =>
            {
                Print("Please select: ", ConsoleColor.Green);
                foreach (var item in all)
                {
                    Print($"{item.index + 1} {item.name}", ConsoleColor.Yellow);
                }

                return all.Count;
            };

            var option = GetUserSelectionFromMenu(menu);
            var selected = all[option - 1].name;

            return selected;
        }

        public static void ListAllManufacturers()
        {
            var all = DataReader
                .GetAllManufacturers()
                .OrderBy(m => m.Name);

                                ;
            foreach (var item in all)
            {
                Print($"{item.Name,-35} {item.Year,-5} {item.Country}" ,ConsoleColor.Cyan);
            }
        }

        public static void ListVehiclesOfManufactureres()
        {
            var manufacturers = DataReader
                .GetAllManufacturers()
                .OrderBy(m => m.Name)
                .Select(m => m.Name);

            var selected = GetUserSelectionFromStrings(manufacturers);

            var cars = DataReader.GetAllCars()
                .Where(car => car.Make == selected)
                .OrderBy(car => car.Model)
                .ThenBy(car => car.Cylinders);

            foreach (var car in cars)
            {
                Print($"{car.Make,-30} {car.Model,-30} {car.Cylinders}", ConsoleColor.Cyan);
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
                Print($"{item.name,-35} {item.count}", ConsoleColor.Cyan);
            }
        }

        public static void ListBestCarsOfManufacturers()
        {
            var countries = DataReader
                .GetAllManufacturers()
                .Select(m => m.Country)
                .Distinct();

            var selected = GetUserSelectionFromStrings(countries);

            var manufactuers = DataReader
                .GetAllManufacturers()
                .Where(m => m.Country == selected)
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
                Print(group.make, ConsoleColor.Cyan);
                foreach (var car in group.cars)
                {
                    Print($"{car.Model,-30} {car.Year,-5} {car.CombinedFe}", ConsoleColor.White);
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
