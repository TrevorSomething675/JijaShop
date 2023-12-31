﻿using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Api.Services.Abstractions.UserProducts
{
    public interface IUserProductsService
    {
		public Task<ProductDto> GetProduct(string name);
		public Task<List<ProductDto>> GetProducts(int pageNumber = 1, Expression<Func<Product, bool>> filter = null);
		public Task UpdateProduct(ProductDto productDto);
		public Task DeleteProduct(ProductDto productDto);
		public Task CreateNewProduct(ProductDto productDto);
	}
}
