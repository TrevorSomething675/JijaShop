using JijaShop.Api.Data.Models.DTOModels;

namespace JijaShop.Api.Services.Abstractions
{
    public interface IProductCartService
    {
        public Task AddToCartProduct(ProductDto productDto);
        public Task DeleteCartPoroduct(ProductDto productDto);
        public Task ClearCartProduct(ProductDto productDto);
    }
}
