using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2Solution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Solution.Controllers
{
    [Route("api/manufacturers")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private IRepositoryService _repo;

        public ManufacturersController(IRepositoryService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManufacturersController>>> GetAllManufacturers()
        {
            var all = await _repo.GetAllManufacturers();
            return Ok(all);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ManufacturersController>> GetManufacturer(string name)
        {
            try
            {
                var res = await _repo.GetManufacturerByName(name);
                return Ok(res);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
