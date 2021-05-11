using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurFirstWebApi.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public class Record
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        [HttpGet]
        public IEnumerable<int> GetMyValuesPlease()
        {
            return new[]
            {
                1, 2, 3, 4
            };
        }

        [HttpGet("detailed")]
        public IEnumerable<Record> GetMoreDetailedValues()
        {
            yield return new Record { X = 2, Y = 2 };
            yield return new Record { X = 1, Y = 2 };
            yield return new Record { X = 1, Y = 1 };
            yield return new Record { X = 0, Y = 3 };
        }
    }
}
