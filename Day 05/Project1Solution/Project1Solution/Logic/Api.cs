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
            throw new NotImplementedException();
        }

        public static IEnumerable<(string manufacturer, int numberOfCars)> GetManufacturerNumberOfCars()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<string> GetAllCountries()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<IGrouping<string, Car>> GetBestCarsOfManufacturersFrom(string country)
        {
            throw new NotImplementedException();
        }

        public static Car GetCarWithLowestCombinedFe()
        {
            throw new NotImplementedException();
        }

        public static double GetAvaerageCityFe()
        {
            throw new NotImplementedException();
        }

        public static int GetNumberOfCounter()
        {
            throw new NotImplementedException();
        }

        public static string GetManufacturerWithHighestAverageCombinedFe()
        {
            throw new NotImplementedException();
        }
    }
}
