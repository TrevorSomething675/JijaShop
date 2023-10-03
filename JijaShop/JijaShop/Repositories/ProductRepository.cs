﻿using JijaShop.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using JijaShop.Models.Entities;

namespace JijaShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly MainContext _context;
        public ProductRepository(MainContext context, ILogger<ProductRepository> logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Product>> GetProducts()
        {
            var resultProducts = await _context.Products
                .Include(prod=>prod.ProductDetails)
                .Include(prod=>prod.ProductOffers).ToListAsync();

            return resultProducts;
        }

        public async Task<Product> GetProduct(int id)
        {
            var resultProduct = await _context.Products.Include(prod => prod.ProductDetails)
                .Include(prod => prod.ProductOffers)
                .FirstOrDefaultAsync(prod => prod.Id == id);

            return resultProduct;
        }

        public async Task CreateNewProduct(Product product)
        {
            try
            {
				product.CreatedDate = DateTime.Now;
                _context.Add(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }

        public async Task DeleteProduct(Product product)
        {
            try
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }

        public async Task UpdateProduct(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }
    }
}
