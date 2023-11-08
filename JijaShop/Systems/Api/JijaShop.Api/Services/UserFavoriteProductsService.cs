using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Data.Models.AuthEntities;
using JijaShop.Api.Services.Abstractions;
using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace JijaShop.Api.Services
{
    public class UserFavoriteProductsService : IUserFavoriteProductsService
    {
        private readonly IProductFavoritesRepository _favoritesRepository;
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<UserFavoriteProductsService> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserFavoriteProductsService(IProductFavoritesRepository favoritesRepository, 
            UserManager<User> userManager, IProductRepository productRepository, 
            IMapper mapper, IHttpContextAccessor contextAccessor,
            ILogger<UserFavoriteProductsService> logger)
        {
            _favoritesRepository = favoritesRepository;
            _productRepository = productRepository;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            var favoriteProducts = await _favoritesRepository.GetProducts(prod => prod.UserId == user.Id);
            var products = _mapper.Map<List<ProductDto>>(favoriteProducts);

            return products;
        }

        public Task GetProduct(string productName)
        {
            throw new NotImplementedException();
        }

        public async Task AddProduct(string productName)
        {
            try
            {
                var product = await _productRepository.GetProduct(productName);
                var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);

                var favoriteProduct = _mapper.Map<FavoriteProduct>(product);
                favoriteProduct.UserId = user.Id;
                favoriteProduct.User = user;

                await _favoritesRepository.AddProduct(favoriteProduct);
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
                var product = await _productRepository.GetProduct(productName);
                var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);

                var favoriteProduct = _mapper.Map<FavoriteProduct>(product);
                favoriteProduct.UserId = user.Id;
                favoriteProduct.User = user;

                await _favoritesRepository.RemoveProduct(favoriteProduct);
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"{ex.Message}");
            }
        }

    }
}
