using JijaShop.Api.Data.Models.DTOModels;

namespace JijaShop.Api.Services.Abstractions
{
	public interface IUserCartProductsService
	{
		public Task<List<ProductDto>> GetProducts();
		public Task GetProduct(string productName);
		public Task AddProduct(string productName);
		public Task RemoveProduct(string productName);
	}
}
