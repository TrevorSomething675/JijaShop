using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Services.Abstractions;
using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using System.Linq.Expressions;
using AutoMapper;

namespace JijaShop.Api.Services
{
	public class ProductFavoritesService : IProductFavoritesService
	{
		private readonly IProductFavoritesRepository _productFavoritesService;
		private readonly IMapper _mapper;

		public ProductFavoritesService(IProductFavoritesRepository productFavoritesService, IMapper mapper)
		{
			_productFavoritesService = productFavoritesService;
			_mapper = mapper;
		}

		public async Task<List<ProductDto>> GetAllProducts(Expression<Func<FavoriteProduct, bool>> filter = null)
		{
			filter = filter ?? (prod => true);

			var favoritesProducts = await _productFavoritesService.GetFavoriteProducts(filter);
			var resultProducts = _mapper.Map<List<ProductDto>>(favoritesProducts);

			return resultProducts;
		}

		public async Task<ProductDto> GetFavoriteProduct(string productName)
		{
			var favoritesProduct = await _productFavoritesService.GetFavoriteProduct(productName);
			var result = _mapper.Map<ProductDto>(favoritesProduct);

			return result;
		}

		public async Task AddFavoriteProduct(ProductDto productDto)
		{
			var productFavorite = _mapper.Map<FavoriteProduct>(productDto);
			await _productFavoritesService.AddFavoriteProduct(productFavorite);
		}

		public async Task RemoveFavoriteProduct(ProductDto productDto)
		{
			var productFavorite = _mapper.Map<FavoriteProduct>(productDto);
			await _productFavoritesService.RemoveFavoriteProduct(productFavorite);
		}
	}
}