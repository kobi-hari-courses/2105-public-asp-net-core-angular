using Project1.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public static class DataReader
    {
        private const string _basePath = "Data";
        private const string _carsFile = "Cars.csv";
        private const string _mfgFile = "Manufacturers.csv";

        public static string[] ToColumns(this string source)
        {
            return source
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();
        }

        public static Car ToCar(this string source)
        {
            var cols = source.ToColumns();

            return new Car
            {
                Year = int.Parse(cols[0]),
                Make = cols[1],
                Model = cols[2],
                Displacement = double.Parse(cols[3]),
                Cylinders = int.Parse(cols[4]),
                CityFe = int.Parse(cols[5]),
                HighwayFe = int.Parse(cols[6]),
                CombinedFe = int.Parse(cols[7])
            };
        }

        public static Manufacturer ToManufacturer(this string source)
        {
            var cols = source
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();

            return new Manufacturer
            {
                Name = cols[0],
                Country = cols[1],
                Year = int.Parse(cols[2])
            };
        }


        public static IEnumerable<Car> GetAllCars()
        {
            return File
                .ReadAllLines($"{_basePath}/{_carsFile}")
                .Skip(1)
                .Where(str => !string.IsNullOrWhiteSpace(str))
                .Select(str => str.ToCar());
        }

        public static IEnumerable<Manufacturer> GetAllManufacturers()
        {
            return File
                .ReadAllLines($"{_basePath}/{_mfgFile}")
                .Where(str => !string.IsNullOrWhiteSpace(str))
                .Select(str => str.ToManufacturer());
        }


    }
}
