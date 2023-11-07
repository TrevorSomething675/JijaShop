using JijaShop.Api.Data.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Api.Repositories.Abstractions
{
	public interface IProductFavoritesRepository
	{
		public Task<FavoriteProduct> GetFavoriteProduct(string name);
		public Task<List<FavoriteProduct>> GetFavoriteProducts(Expression<Func<FavoriteProduct, bool>> filter = null);
		public Task AddFavoriteProduct(FavoriteProduct cartProduct);
		public Task RemoveFavoriteProduct(FavoriteProduct cartProduct);
	}
}
