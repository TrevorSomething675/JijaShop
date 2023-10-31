using JijaShop.Api.Data.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Api.Repositories.Abstractions
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts(Expression<Func<Product, bool>> filter = null);
        public Task<Product> GetProduct(string name);
        public Task CreateNewProduct(Product productDto);
        public Task DeleteProduct(Product productDto);
        public Task UpdateProduct(Product productDto);
    }
}
