using System;
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
                .Select((m, index) => (name: m.Name, index: index))
                .ToList();

            Func<int> menu = () =>
            {
                Print("Please select a manufacturer: ", ConsoleColor.Green);
                foreach (var item in manufacturers)
                {
                    Print($"{item.index + 1} {item.name}", ConsoleColor.Yellow);
                }
                return manufacturers.Count;
            };

            var option = GetUserSelectionFromMenu(menu);
            var selected = manufacturers[option - 1].name;

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
        }

        public static void ListGeneralHighlights()
        {
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
