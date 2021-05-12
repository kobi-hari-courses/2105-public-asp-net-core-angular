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

        [HttpGet("{username}", Name =nameof(GetUser))]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            try
            {
                var res = await _repo.GetUserByUsername(username);
                return Ok(res);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            try
            {
                var res = await _repo.AddUser(user);
                return CreatedAtRoute(nameof(GetUser), new { username = res.Username }, res);
            } catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("")]
        public async Task<ActionResult> DeleteUser(string username)
        {
            try
            {
                await _repo.DeleteUser(username);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
