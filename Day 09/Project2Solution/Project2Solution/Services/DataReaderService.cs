using Project2Solution.Entities;
using Project2Solution.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Solution.Services
{
    public class DataReaderService : IDataReaderService
    {
        // TODO: This should be moved to an external config file
        private const string _basePath = "Data";
        private const string _carsFile = "Cars.csv";
        private const string _mfgFile = "Manufacturers.csv";

        public Task<IEnumerable<Car>> GetAllCars()
        {
            return Task.FromResult(File
                .ReadAllLines($"{_basePath}/{_carsFile}")
                .Skip(1)
                .Where(str => !string.IsNullOrWhiteSpace(str))
                .Select(str => str.ToCar()));
        }

        public Task<IEnumerable<Manufacturer>> GetAllManufacturers()
        {
            return Task.FromResult(File
                .ReadAllLines($"{_basePath}/{_mfgFile}")
                .Where(str => !string.IsNullOrWhiteSpace(str))
                .Select(str => str.ToManufacturer()));
        }

    }
}
