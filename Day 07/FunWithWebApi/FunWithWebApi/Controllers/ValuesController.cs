using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithWebApi.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<int> _allMyNumbers = new List<int>
        {
            10,
            20,
            35
        };

        public ValuesController()
        {
            Console.WriteLine("Values controller created");
        }

        [HttpGet("")]
        public IEnumerable<int> GetAllValues()
        {
            return _allMyNumbers;
        }

        [HttpGet("sum")] 
        public int GetSumOfAllValues()
        {
            return _allMyNumbers.Sum();
        }

        [HttpPost("")]
        public void AddNewNumber([FromBody]int value)
        {
            _allMyNumbers.Add(value);
        }

        [HttpDelete("{index}")]
        public void DeleteNumber(int index)
        {
            _allMyNumbers.RemoveAt(index);
        }

        [HttpPut("{index}")]
        public void ReplaceNumber(int index, [FromBody] int value)
        {
            _allMyNumbers[index] = value;
        }
    }
}
