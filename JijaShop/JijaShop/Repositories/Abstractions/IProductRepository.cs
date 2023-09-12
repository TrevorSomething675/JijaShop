using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;

namespace JijaShop.Repositories.Abstractions
{
    public interface IProductRepository
    {
        public Task<Product> GetProduct(int id);
        public Task CreateNewProduct(ProductDto productDto);
        public Task DeleteProduct(ProductDto productDto);
        public Task UpdateProduct(ProductDto productDto);
    }
}
