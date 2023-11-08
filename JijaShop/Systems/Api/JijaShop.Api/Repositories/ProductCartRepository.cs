using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using JijaShop.Api.Data;

namespace JijaShop.Api.Repositories
{
    public class ProductCartRepository : IProductCartRepository
	{
        private readonly ILogger<ProductCartRepository> _logger;
        private readonly MainContext _context;
        public ProductCartRepository(MainContext context, ILogger<ProductCartRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CartProduct> GetProduct(string name)
        {
            var resultProduct = await _context.CartProducts
                .Include(prod => prod.ProductDetails)
                .Include(prod => prod.ProductOffers)
                .Include(prod => prod.ProductImage)
                .FirstOrDefaultAsync(prod => prod.Name == name);

            return resultProduct;
        }

        public async Task<List<CartProduct>> GetProducts(Expression<Func<CartProduct, bool>> filter = null)
        {
            filter = filter ?? (prod => true);

            var resultProducts = await _context.CartProducts
                .Include(prod => prod.ProductDetails)
                .Include(prod => prod.ProductOffers)
                .Include(prod => prod.ProductImage)
                .Where(filter).ToListAsync();

            return resultProducts;

		}

        public async Task AddProduct(CartProduct cartProduct)
        {
            try
            {
                _context.CartProducts.Add(cartProduct);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogDebug($"{ex.Message}");
            }
        }

        public async Task RemoveProduct(CartProduct cartProduct)
        {
            try
            {
                _context.CartProducts.Remove(cartProduct);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }
    }
}
