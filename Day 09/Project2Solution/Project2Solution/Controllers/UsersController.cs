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
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepositoryService _repo;

        public UsersController(IRepositoryService repo)
        {
            _repo = repo;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetManufacturer(string username)
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
