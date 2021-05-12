using Project2Solution.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project2Solution.Services
{
    public interface IDataReaderService
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<IEnumerable<Manufacturer>> GetAllManufacturers();
    }
}