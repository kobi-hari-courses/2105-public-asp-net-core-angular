using Project2Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Solution.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private string _currentUsername;
        private IRepositoryService _repo;

        public CurrentUserService(IRepositoryService repo)
        {
            _repo = repo;
        }

        public Task SetCurrentUser(string username)
        {
            _currentUsername = username;
            return Task.CompletedTask;
        }

        public Task<User> GetCurrentUser()
        {
            return _repo.GetUserByUsername(_currentUsername);
        }

        public Task<IEnumerable<Car>> GetCarsOfCurrentUser()
        {
            return _repo.GetAllCarsOfUser(_currentUsername);
        }
    }
}
