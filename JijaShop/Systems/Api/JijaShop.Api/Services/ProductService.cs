﻿using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Services.Abstractions;
using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using JijaShop.Extensions.SettingsModel;
using System.Linq.Expressions;
using JijaShop.Extentions;
using AutoMapper;

namespace JijaShop.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly MainSettings _mainSettings;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            _mainSettings = Settings.Load<MainSettings>("Main");
            _productRepository = productRepository;
            _appEnvironment = appEnvironment;
            _mapper = mapper;
        }

        public async Task<ProductDto?> GetProduct(string name)
        {
            var product = _mapper.Map<ProductDto>(await _productRepository.GetProduct(name));

            return product;
        }

        public async Task<List<ProductDto>?> GetProducts(int pageNumber = 1, Expression<Func<Product, bool>> filter = null)
        {
            var pageResult = 12f;
            var pageCount = Math.Ceiling(_productRepository.GetProducts(filter).Result.Count() / pageResult);

            var products = _productRepository.GetProducts(filter).Result
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

            using (var fileStream = new FileStream($"{_appEnvironment.WebRootPath}/{_mainSettings.ProductImagesPath}/{productDto.ProductImage.Image.FileName}", FileMode.Create))
            {
                productDto.ProductImage.Image.CopyTo(fileStream);
            }

            product.ProductImage.ImageName = productDto.ProductImage.Image.FileName;
            product.ProductImage.ImagePath = $"{_mainSettings.ProductImagesPath}/{productDto.ProductImage.Image.FileName}";

            await _productRepository.CreateProduct(product);
        }
    }
}
