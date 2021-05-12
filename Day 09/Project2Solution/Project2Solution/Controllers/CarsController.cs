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
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private IRepositoryService _repo;

        public CarsController(IRepositoryService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars([FromServices] ICurrentUserService currentUser)
        {
            var username = await currentUser.GetCurrentUsername();

            if (string.IsNullOrWhiteSpace(username))
            {
                var all = await _repo.GetAllCars();
                return Ok(all);
            } else
            {
                var all = await _repo.GetAllCarsOfUser(username);
                return Ok(all);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(Guid id)
        {
            try
            {
                var car = await _repo.GetCarById(id);
                return Ok(car);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
