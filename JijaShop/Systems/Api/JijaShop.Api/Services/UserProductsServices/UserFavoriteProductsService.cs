using JijaShop.Api.Services.Abstractions.UserProducts;
using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Data.Models.AuthEntities;
using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using JijaShop.Api.Repositories;

namespace JijaShop.Api.Services.UserProducts
{
    public class UserFavoriteProductsService : IUserFavoriteProductsService
    {
        private readonly IProductFavoritesRepository _productFavoriteRepository;
        private readonly ILogger<UserFavoriteProductsService> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserFavoriteProductsService(IProductFavoritesRepository productFavoriteRepository,
            UserManager<User> userManager, IProductRepository productRepository,
            IMapper mapper, IHttpContextAccessor contextAccessor, ILogger<UserFavoriteProductsService> logger)
        {
            _productFavoriteRepository = productFavoriteRepository;
            _productRepository = productRepository;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            var favoriteProducts = await _productFavoriteRepository.GetProducts(prod => prod.UserId == user.Id);
            var productsDto = _mapper.Map<List<ProductDto>>(favoriteProducts);

            return productsDto;
        }

        public async Task<ProductDto> GetProduct(string productName)
        {
			var favoriteProduct = await _productFavoriteRepository.GetProduct(productName);
			var productDto = _mapper.Map<ProductDto>(favoriteProduct);

            return productDto;
		}

        public async Task AddProduct(string productName)
        {
            try
            {
                var product = await _productRepository.GetProduct(productName);
                var productDto = _mapper.Map<ProductDto>(product);
                var favoriteProd = _mapper.Map<FavoriteProduct>(productDto);
                var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
                favoriteProd.User = user;
                favoriteProd.UserId = user.Id;

				await _productFavoriteRepository.AddProduct(favoriteProd);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}");
            }
        }

        public async Task RemoveProduct(string productName)
        {
            try
            {
                var favoriteProd = await _productFavoriteRepository.GetProduct(productName);
                await _productFavoriteRepository.RemoveProduct(favoriteProd);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}");
            }
        }

    }
}
