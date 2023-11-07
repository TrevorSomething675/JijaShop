using JijaShop.Api.Data.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Api.Repositories.Abstractions
{
	public interface IProductCartRepository
	{
		public Task<CartProduct> GetCartProduct(string name);
		public Task<List<CartProduct>> GetCartProducts(Expression<Func<CartProduct, bool>> filter = null);
		public Task AddCartProduct(CartProduct cartProduct);
		public Task RemoveCartProduct(CartProduct cartProduct);
	}
}
