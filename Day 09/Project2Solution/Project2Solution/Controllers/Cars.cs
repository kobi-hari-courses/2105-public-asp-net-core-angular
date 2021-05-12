using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2Solution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Solution.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class Cars : ControllerBase
    {
        private IRepositoryService _repo;

        public Cars(IRepositoryService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cars>>> GetAllCars()
        {
            var all = await _repo.GetAllCars();
            return Ok(all);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cars>> GetCar(Guid id)
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
