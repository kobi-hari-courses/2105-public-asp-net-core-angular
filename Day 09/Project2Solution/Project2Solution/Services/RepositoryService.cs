using Project2Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Solution.Services
{
    public class RepositoryService
    {
        private bool _isAllDataLoaded = false;
        private Dictionary<Guid, Car> _cars;
        private Dictionary<string, Manufacturer> _manufacturers;
        private IDataReaderService _dataReader;

        public RepositoryService(IDataReaderService dataReader)
        {
            _dataReader = dataReader;
        }

        private async Task _ensureAllDataLoaded()
        {
            if (_isAllDataLoaded) return;

            _isAllDataLoaded = true;
            _cars = (await _dataReader.GetAllCars())
                .ToDictionary(c => c.Id);

            _manufacturers = (await _dataReader.GetAllManufacturers())
                .ToDictionary(m => m.Name);
        }
    }
}
