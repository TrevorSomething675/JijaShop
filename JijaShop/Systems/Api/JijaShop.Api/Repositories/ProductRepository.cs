using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using JijaShop.Api.Data;

namespace JijaShop.Api.Repositories
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

        public async Task<List<Product>> GetProducts(Expression<Func<Product, bool>> filter = null)
        {
            filter = filter ?? (prod => true);

            var resultProducts = await _context.Products
                .Include(prod => prod.ProductDetails)
                .Include(prod => prod.ProductOffers)
                .Include(prod => prod.ProductImage)
                .Where(filter).ToListAsync();

            return resultProducts;

        }

        public async Task<Product> GetProduct(string name)
        {
            var resultProduct = await _context.Products
                .Include(prod => prod.ProductDetails)
                .Include(prod => prod.ProductOffers)
                .Include(prod => prod.ProductImage)
                .FirstOrDefaultAsync(prod => prod.Name == name);

            return resultProduct;
        }

        public async Task CreateNewProduct(Product product)
        {
            try
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
				_logger.LogInformation($"{ex.Message}");
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
				_logger.LogInformation($"{ex.Message}");
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
				_logger.LogInformation($"{ex.Message}");
			}
        }
    }
}
