using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Services.Abstractions;

namespace JijaShop.Api.Services
{
	public class UserCartProductsService : IUserCartProductsService
	{
		public Task AddProduct(string productName)
		{
			throw new NotImplementedException();
		}

		public Task GetProduct(string productName)
		{
			throw new NotImplementedException();
		}

		public Task<List<ProductDto>> GetProducts()
		{
			throw new NotImplementedException();
		}

		public Task RemoveProduct(string productName)
		{
			throw new NotImplementedException();
		}
	}
}
