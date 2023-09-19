using JijaShop.Repositories.Abstractions;
using JijaShop.Services.Abstractions;
using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using AutoMapper;

namespace JijaShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task CreateNewProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.CreateNewProduct(product);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        } 
    }
}
