using JijaShop.Models.Entities;

namespace JijaShop.Repositories.Abstractions
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();
		public Task<Product> GetProduct(int id);
        public Task CreateNewProduct(Product productDto);
        public Task DeleteProduct(Product productDto);
        public Task UpdateProduct(Product productDto);
    }
}
