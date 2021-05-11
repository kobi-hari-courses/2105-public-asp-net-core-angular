using AspNetApp.Contracts;
using AspNetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetApp.Services
{
    public class MockProductsService : IProductsService
    {
        private List<Product> _products = new List<Product>();
        public MockProductsService()
        {
            for (int i = 1; i <= 10; i++)
            {
                _products.Add(new Product(i, $"Product NO.{i}"));
            }
        }
        public async Task<Product> AddNewProduct(Product p)
        {
            await Task.Delay(500);
            var productToAdd = p with { Id = _products.Max(x => x.Id) + 1 };
            _products.Add(productToAdd);
            return  productToAdd;
        }

   
        public Task<List<Product>> GetAll()
        {
            return Task.FromResult(_products);
        }

        public Task<Product> GetItemById(int id)
        {
            //await Task.Delay(500);
            //return _products.FirstOrDefault(x => x.Id == id);

            var ret = _products.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(ret);
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var itemToDelete = await GetItemById(id);
            if(itemToDelete == null)
            {
                throw new Exception("Missing...");
            }
            _products.Remove(itemToDelete);
            return itemToDelete;
        }

        public async Task<Product> UpdateProduct(int id, Product p)
        {
            var itemToUpdate = await GetItemById(id);
            if (itemToUpdate == null)
            {
                throw new Exception("Missing...");
            }
            _products.Remove(itemToUpdate);
            Product item = p with { Id = id };
            _products.Add(item);
            return item;

        }
    }
}
