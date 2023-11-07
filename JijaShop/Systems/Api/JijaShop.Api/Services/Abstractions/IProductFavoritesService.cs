using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Api.Services.Abstractions
{
	public interface IProductFavoritesService
	{
		public Task AddFavoriteProduct(ProductDto productDto);
		public Task RemoveFavoriteProduct(ProductDto productDto);
		public Task<ProductDto> GetFavoriteProduct(string productName);
		public Task<List<ProductDto>> GetAllProducts(Expression<Func<FavoriteProduct, bool>> filter = null);
	}
}