using AspNetApp.Contracts;
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
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }


        [HttpGet("GetOS", Name = nameof(GetOS))]
        public ActionResult<string> GetOS()
        {
            return Ok(Environment.OSVersion);
        }


        [HttpGet(Name = nameof(GetAll))]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            // IO : 
            // 1. db connection
            // 2. network
            // 3. read write files
            var products = await _productsService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productsService.GetItemById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost(Name = nameof(AddNewProduct))]
        public async Task<ActionResult<Product>> AddNewProduct(Product p)
        {
            var newProduct = await _productsService.AddNewProduct(p);
            return Ok(newProduct);
        }

        [HttpPut("{id}", Name = nameof(UpdateProduct))]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product p)
        {
            try
            {
                var item = await _productsService.UpdateProduct(id, p);
                return Ok(item);
            }
            catch (Exception ex) when (ex.Message.Contains("Missing"))
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}", Name = nameof(DeleteProduct))]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                var item = await _productsService.DeleteProduct(id);
                return Ok(item);
            }
            catch (Exception ex) when (ex.Message.Contains("Missing"))
            {
                return NotFound();
            }
        }



    }
}
