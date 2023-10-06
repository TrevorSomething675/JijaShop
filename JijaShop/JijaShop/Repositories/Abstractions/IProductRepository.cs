using JijaShop.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Repositories.Abstractions
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts(Expression<Func<Product, bool>> filter = null);
		public Task<Product> GetProduct(int id);
        public Task CreateNewProduct(Product productDto);
        public Task DeleteProduct(Product productDto);
        public Task UpdateProduct(Product productDto);
    }
}
