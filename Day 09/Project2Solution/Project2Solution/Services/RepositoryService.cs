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
        private Dictionary<string, User> _users = new();
        private HashSet<UserCar> _userCars = new();
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

        public async Task<List<Car>> GetAllCars()
        {
            await _ensureAllDataLoaded();
            return _cars.Values.ToList();
        }

        public async Task<List<Manufacturer>> GetAllManufacturers()
        {
            await _ensureAllDataLoaded();
            return _manufacturers.Values.ToList();
        }

        public async Task<Car> GetCarById(Guid id)
        {
            await _ensureAllDataLoaded();
            return _cars[id];
        }

        public async Task<Manufacturer> GetManufacturerByName(string name)
        {
            await _ensureAllDataLoaded();
            return _manufacturers[name];
        }

        public Task<List<User>> GetAllUsers()
        {
            return Task.FromResult(_users.Values.ToList());
        }

        public Task<List<UserCar>> GetAllUserCars()
        {
            // important, even though _userCars is already a list, I am calling ToList
            // in order to create a copy of the list that is stored in the repository.
            // If I return the original list references, it can be modified from outside the repository
            // without the repository being aware of it (!!!)
            return Task.FromResult(_userCars.ToList());
        }

        public Task<User> GetUserByUsername(string username)
        {
            return Task.FromResult(_users[username]);
        }

        public Task<User> AddUser(User user)
        {
            if (_users.ContainsKey(user.Username))
                throw new ArgumentException($"User with username {user.Username} already exists");

            _users.Add(user.Username, user);
            return Task.FromResult(user);
        }

        public Task<User> ModifyUser(User user)
        {
            if (!_users.ContainsKey(user.Username))
                throw new ArgumentException($"User with username {user.Username} does not exist");

            _users[user.Username] = user;
            return Task.FromResult(user);
        }

        public Task DeleteUser(string username)
        {
            if (!_users.ContainsKey(username))
                throw new ArgumentException($"User with username {username} does not exist");

            // remove the user itself
            _users.Remove(username);

            // remove it from the User Cards collection
            _userCars.RemoveWhere(uc => uc.Username == username);

            return Task.CompletedTask;
        }

        public async Task<UserCar> AddUserCar(UserCar userCar)
        {
            await _ensureAllDataLoaded();

            // records are comparable, and are by default compared by the value of their properties
            // so UserCar can actually be found by its value inside a hashset, so this takes O(1)
            if (_userCars.Contains(userCar))
                throw new ArgumentException($"Already have a record with car = {userCar.CarId} and user = {userCar.Username}");

            if (!_users.ContainsKey(userCar.Username))
                throw new ArgumentException($"User with username {userCar.Username} does not exist");

            if (!_cars.ContainsKey(userCar.CarId))
                throw new ArgumentException($"Car with id {userCar.CarId} does not exist");

            _userCars.Add(userCar);
            return userCar;
        }

        public Task RemoveUserCar(UserCar userCar)
        {
            if (!_userCars.Contains(userCar))
                throw new ArgumentException($"Could not find a record with car = {userCar.CarId} and user = {userCar.Username}");

            _userCars.Remove(userCar);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Car>> GetAllCarsOfUser(string username)
        {
            await _ensureAllDataLoaded();

            return _userCars
                .Where(uc => uc.Username == username)
                .Select(uc => _cars[uc.CarId]);
        }

        public async Task<IEnumerable<User>> GetAllUsersOfCar(Guid carId)
        {
            await _ensureAllDataLoaded();

            return _userCars
                .Where(uc => uc.CarId == carId)
                .Select(uc => _users[uc.Username]);
        }



    }
}
