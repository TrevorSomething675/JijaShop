using JijaShop.Api.Data.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Api.Repositories.Abstractions
{
	public interface IProductCartRepository
	{
		public Task<CartProduct> GetProduct(string name);
		public Task<List<CartProduct>> GetProducts(Expression<Func<CartProduct, bool>> filter = null);
		public Task AddProduct(CartProduct cartProduct);
		public Task RemoveProduct(CartProduct cartProduct);
	}
}
