using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Services.Abstractions
{
    public interface IProductService
    {
		public Task CreateNewProduct(ProductDto productDto);
		public Task<List<ProductDto>> GetProducts(int pageNumber = 1, Expression<Func<Product, bool>> filter = null);
	}
}
