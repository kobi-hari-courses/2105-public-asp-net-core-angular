using Project1Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Solution
{
    public static class Api
    {
        public static IEnumerable<Manufacturer> GetAllManufacturers()
        {
            return DataReader
                .GetAllManufacturers()
                .OrderBy(m => m.Name);
        }

        public static IEnumerable<Car> GetCarsOfManufacturer(string manufaturer)
        {
            return DataReader.GetAllCars()
                .Where(car => car.Make == manufaturer)
                .OrderBy(car => car.Model)
                .ThenBy(car => car.Cylinders);
        }

        public static IEnumerable<(string manufacturer, int numberOfCars)> GetManufacturerNumberOfCars()
        {
            return DataReader.GetAllCars()
                .GroupBy(car => car.Make)
                .Select(group => (manufacturer: group.Key, numberOfCars: group.Count()));
        }

        public static IEnumerable<string> GetAllCountries()
        {
            return DataReader.GetAllManufacturers()
                .Select(m => m.Country)
                .Distinct();
        }

        public static IEnumerable<(string make, IEnumerable<Car> cars)> GetBestCarsOfManufacturersFrom(string country)
        {
            var manufacturers = DataReader.GetAllManufacturers()
                .Where(m => m.Country == country)
                .Select(m => m.Name)
                .ToHashSet();

            return DataReader.GetAllCars()
                .Where(car => manufacturers.Contains(car.Make))
                .GroupBy(car => car.Make)
                .Select(group => (
                    make: group.Key, 
                    cars: group.OrderByDescending(car => car.CombinedFe)
                               .Take(3))
                    );
        }

        public static Car GetCarWithLowestCombinedFe()
        {
            // TODO: Use aggrtegate to imrove from O(N log(N)) to O(N)
            return DataReader
                .GetAllCars()
                .OrderBy(car => car.CombinedFe)
                .First();
        }

        public static double GetAvaerageCityFe()
        {
            return DataReader
                .GetAllCars()
                .Average(car => car.CityFe);
        }

        public static int GetNumberOfCounter()
        {
            return Api.GetAllCountries().Count();
        }

        public static (string name, double avg) GetManufacturerWithHighestAverageCombinedFe()
        {
            return DataReader.GetAllCars()
                .GroupBy(car => car.Make)
                .Select(group => (name: group.Key, avg: group.Average(car => car.CombinedFe)))
                .OrderByDescending(tuple => tuple.avg)
                .First();
        }
    }
}
