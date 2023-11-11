using JijaShop.Api.Data.Models.DTOModels;

namespace JijaShop.Api.Services.Abstractions.UserProducts
{
    public interface IUserFavoriteProductsService
    {
        public Task<List<ProductDto>> GetProducts();
        public Task<ProductDto> GetProduct(string productName);
        public Task AddProduct(string productName);
        public Task RemoveProduct(string productName);
    }
}