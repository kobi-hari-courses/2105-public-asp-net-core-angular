using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise4Solution.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<string> _movies = new List<string>
        {
            "Reservoir Dogs",
            "Pulp Fiction",
            "Kill Bill 1",
            "Kill Bill 2",
            "Inglorious Bastards",
            "Django Unleashed"
        };

        [HttpGet]
        public IEnumerable<string> GetAll([FromQuery] string startsWith)
        {
            var prefix = startsWith ?? "";
            return _movies.Where(m => m.StartsWith(prefix));
        }

        [HttpPost]
        public void Add([FromBody] string movie)
        {
            _movies.Add(movie);
        }

        [HttpPut("{index}")]
        public void Replace(int index, [FromBody] string movie)
        {
            _movies[index] = movie;
        }

        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            _movies.RemoveAt(index);
        }

    }
}
