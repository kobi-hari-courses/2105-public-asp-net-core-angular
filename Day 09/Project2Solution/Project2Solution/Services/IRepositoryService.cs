using Project2Solution.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project2Solution.Services
{
    public interface IRepositoryService
    {
        Task<User> AddUser(User user);
        Task<UserCar> AddUserCar(UserCar userCar);
        Task DeleteUser(string username);
        Task<List<Car>> GetAllCars();
        Task<IEnumerable<Car>> GetAllCarsOfUser(string username);
        Task<List<Manufacturer>> GetAllManufacturers();
        Task<List<UserCar>> GetAllUserCars();
        Task<List<User>> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersOfCar(Guid carId);
        Task<Car> GetCarById(Guid id);
        Task<Manufacturer> GetManufacturerByName(string name);
        Task<User> GetUserByUsername(string username);
        Task<User> ModifyUser(User user);
        Task RemoveUserCar(UserCar userCar);
    }
}