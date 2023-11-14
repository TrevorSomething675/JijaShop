using JijaShop.Api.Services.Abstractions.UserProducts;
using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Data.Models.AuthEntities;
using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace JijaShop.Api.Services.UserProducts
{
    public class UserCartProductsService : IUserCartProductsService
    {
        private readonly IProductCartRepository _productCartRepository;
		private readonly ILogger<UserCartProductsService> _logger;
		private readonly IHttpContextAccessor _contextAccessor;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

		public UserCartProductsService(IHttpContextAccessor contextAccessor, IMapper mapper,
			ILogger<UserCartProductsService> logger, IProductRepository productRepository,
            IProductCartRepository productCartRepository, UserManager<User> userManager)
        {
            _productCartRepository = productCartRepository;
			_productRepository = productRepository;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            var cartProducts = await _productCartRepository.GetProducts(prod=>prod.UserId == user.Id);
            var productsDto = _mapper.Map<List<ProductDto>>(cartProducts);

            return productsDto;
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

                var cartProduct = _mapper.Map<CartProduct>(product);
                cartProduct.User = user;
                cartProduct.UserId = user.Id;

                await _productCartRepository.AddProduct(cartProduct);
			}
            catch(Exception ex)
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

                var cartProduct = _mapper.Map<CartProduct>(product);
                cartProduct.User = user;
                cartProduct.UserId = user.Id;

                await _productCartRepository.RemoveProduct(cartProduct);
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"{ex.Message}");
            }
        }
    }
}
