using CoursesApp.Model.Entities;
using CoursesApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private IRepositoryService _repo;
        private IIdService _idService;

        public CoursesController(IRepositoryService repo, IIdService idService)
        {
            _repo = repo;
            _idService = idService;

            Console.WriteLine("The user is: " + _idService.User);
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            var all = await _repo.GetAllCourses();
            return Ok(all);
        }

        [HttpGet("{id}", Name = nameof(GetSpecificCourse))]
        public async Task<ActionResult<Course>> GetSpecificCourse(Guid id, [FromServices] IRepositoryService service)
        {
            var course = (await _repo
                .GetAllCourses())
                .SingleOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            } else
            {
                return Ok(course);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Course>> AddCourse([FromBody] Course value)
        {
            var createdObject = await _repo.AddCourse(value);
            return CreatedAtRoute(nameof(GetSpecificCourse), new { id = createdObject.Id }, createdObject);
        }


    }
}
