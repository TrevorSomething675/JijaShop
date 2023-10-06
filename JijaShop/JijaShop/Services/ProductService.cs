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
        public Task<Product> GetProduct(int id)
        {
            var product = _productRepository.GetProduct(id);
            return product;
        }
        public async Task<List<ProductDto>?> GetProducts(int pageNumber = 1)
        {
            var pageResult = 6f;
            var pageCount = Math.Ceiling(_productRepository.GetProducts().Result.Count() / pageResult);

            var products = _productRepository.GetProducts().Result
                .Skip((int)pageCount).ToList()
                .Take((int)pageResult * pageNumber).ToList();

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        } 

        public async Task UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateProduct(product);
        }

        public async Task DeleteProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.DeleteProduct(product);
        }

        public async Task CreateNewProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.CreateNewProduct(product);
        }

    }
}