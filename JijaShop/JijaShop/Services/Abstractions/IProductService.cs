using JijaShop.Models.DTOModels;

namespace JijaShop.Services.Abstractions
{
    public interface IProductService
    {
		public Task CreateNewProduct(ProductDto productDto);
		public Task<List<ProductDto>> GetProducts(int pageNumber = 1);
	}
}
