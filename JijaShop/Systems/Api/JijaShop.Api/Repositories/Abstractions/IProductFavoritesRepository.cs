using JijaShop.Api.Data.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Api.Repositories.Abstractions
{
	public interface IProductFavoritesRepository
	{
		public Task<FavoriteProduct> GetProduct(string name, Expression<Func<FavoriteProduct, bool>> filter = null);
		public Task<List<FavoriteProduct>> GetProducts(Expression<Func<FavoriteProduct, bool>> filter = null);
		public Task AddProduct(FavoriteProduct cartProduct);
		public Task RemoveProduct(FavoriteProduct cartProduct);
	}
}
