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
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars(
            [FromQuery] string make, 
            [FromServices] ICurrentUserService currentUser
            )
        {
            var username = await currentUser.GetCurrentUsername();
            IEnumerable<Car> res = Enumerable.Empty<Car>();

            if (string.IsNullOrWhiteSpace(username))
            {
                res = await _repo.GetAllCars();
            } else
            {
                res = await _repo.GetAllCarsOfUser(username);
            }

            if (!string.IsNullOrWhiteSpace(make))
            {
                res = res.Where(c => c.Make == make);
            }

            return Ok(res);
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
