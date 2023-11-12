using JijaShop.Api.Services.Abstractions.UserProducts;
using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Services.Abstractions;
using JijaShop.Api.Data.Models.Entities;
using System.Linq.Expressions;
using AutoMapper;

namespace JijaShop.Api.Services.UserProducts
{
    public class UserProductsService : IUserProductsService
    {
        private readonly IUserFavoriteProductsService _favoriteProductsService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public UserProductsService(IUserFavoriteProductsService favoriteProductsService, IProductService productService,
			IMapper mapper)
        {
            _favoriteProductsService = favoriteProductsService;
            _productService = productService;
            _mapper = mapper;
        }

		public Task CreateNewProduct(ProductDto productDto)
		{
			throw new NotImplementedException();
		}

		public Task DeleteProduct(ProductDto productDto)
		{
			throw new NotImplementedException();
		}

		public async Task<ProductDto> GetProduct(string productName)
		{
			var product = await _productService.GetProduct(productName);
			var favoriteProduct = await _favoriteProductsService.GetProduct(productName);

			if(product != null)
			{
				product = favoriteProduct;
			}

			return product;
		}

		public async Task<List<ProductDto>> GetProducts(int pageNumber = 1, Expression<Func<Product, bool>> filter = null)
		{
			var products = await _productService.GetProducts(pageNumber, filter);
			var favoriteProduct = await _favoriteProductsService.GetProducts();

			foreach (var favoriteProd in favoriteProduct)
			{
				var product = products.FirstOrDefault(prod => prod.Name == favoriteProd.Name);
				if(product != null)
				{
					int index = products.IndexOf(product);
					product.IsFavorite = true;
					products[index] = product;
				}
			}
			var userProducts = _mapper.Map<List<ProductDto>>(products);

			return userProducts;
		}

		public Task UpdateProduct(ProductDto productDto)
		{
			throw new NotImplementedException();
		}
	}
}
