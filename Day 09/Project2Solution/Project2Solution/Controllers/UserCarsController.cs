using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2Solution.Entities;
using Project2Solution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Solution.Controllers
{
    [Route("api/usercars")]
    [ApiController]
    public class UserCarsController : ControllerBase
    {
        private IRepositoryService _repo;

        public UserCarsController(IRepositoryService repo)
        {
            _repo = repo;
        }

        [HttpPost("")]
        public async Task<ActionResult<UserCar>> AddUserCar(UserCar value)
        {
            try
            {
                var res = await _repo.AddUserCar(value);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{username}/{carId}")]
        public async Task<ActionResult> DeleteUserCar(string username, Guid carId)
        {
            var value = new UserCar(Username: username, CarId: carId);
            try
            {
                await _repo.RemoveUserCar(value);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<IEnumerable<Car>>> CarsOfUser(string username)
        {
            try
            {
                var all = await _repo.GetAllCarsOfUser(username);
                return Ok(all);

            } catch
            {
                return NotFound();
            }
        }


    }
}
