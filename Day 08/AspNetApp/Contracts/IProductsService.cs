using AspNetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetApp.Contracts
{
    public interface IProductsService
    {
        Task<List<Product>> GetAll();

        Task<Product> GetItemById(int id);

        Task<Product> DeleteProduct(int id);

        Task<Product> UpdateProduct(int id, Product p);

        Task<Product> AddNewProduct(Product p);

    }
}
