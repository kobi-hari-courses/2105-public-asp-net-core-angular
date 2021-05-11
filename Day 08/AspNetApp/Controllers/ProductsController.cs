using AspNetApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>();
        private readonly ILogger<ProductsController> _logger;
        static ProductsController()
        {
            for (int i = 1; i <= 10; i++)
            {
                _products.Add(new Product(i, $"Product NO.{i}"));
            }
        }

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = nameof(GetAll))]
        public ActionResult<List<Product>> GetAll()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost(Name = nameof(AddNewProduct))]
        public ActionResult<Product> AddNewProduct(Product p)
        {
            var productToAdd = p with { Id = _products.Max(x=>x.Id) + 1 };
            _products.Add(productToAdd);
            return Ok(productToAdd);
        }
      
        [HttpPut("{id}", Name = nameof(UpdateProduct))]
        public ActionResult<Product> UpdateProduct(int id, Product p)
        {
            var productToUpdate = _products.FirstOrDefault(x => x.Id == id);
            if(productToUpdate == null)
            {
                return NotFound();
            }
            _products.Remove(productToUpdate);
            Product item = p with { Id = id };
            _products.Add(item);
            return Ok(item);
        }

        [HttpDelete("{id}", Name = nameof(DeleteProduct))]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var productToDelete = _products.FirstOrDefault(x => x.Id == id);
            if (productToDelete == null)
            {
                return NotFound();
            }
            _products.Remove(productToDelete);
            return Ok(productToDelete);
        }



    }
}
