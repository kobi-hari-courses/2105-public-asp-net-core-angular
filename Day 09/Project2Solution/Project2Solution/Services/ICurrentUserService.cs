using Project2Solution.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project2Solution.Services
{
    public interface ICurrentUserService
    {
        Task<IEnumerable<Car>> GetCarsOfCurrentUser();
        Task<User> GetCurrentUser();
        Task SetCurrentUser(string username);
    }
}