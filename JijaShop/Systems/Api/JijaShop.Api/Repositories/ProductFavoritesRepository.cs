using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using JijaShop.Api.Data;

namespace JijaShop.Api.Repositories
{
	public class ProductFavoritesRepository : IProductFavoritesRepository
	{
		private readonly ILogger<ProductFavoritesRepository> _logger;
		private readonly MainContext _context;

		public ProductFavoritesRepository(ILogger<ProductFavoritesRepository> logger, MainContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<List<FavoriteProduct>> GetFavoriteProducts(Expression<Func<FavoriteProduct, bool>> filter = null)
		{
			filter = filter ?? (prod => true);

			var resultProducts = await _context.FavoriteProducts
                .Include(prod => prod.ProductDetails)
                .Include(prod => prod.ProductOffers)
                .Include(prod => prod.ProductImage)
                .Where(filter).ToListAsync();

            return resultProducts;
		}

		public async Task<FavoriteProduct> GetFavoriteProduct(string name)
		{
			var resultProduct = await _context.FavoriteProducts
                .Include(prod => prod.ProductDetails)
                .Include(prod => prod.ProductOffers)
                .Include(prod => prod.ProductImage)
                .FirstOrDefaultAsync(prod => prod.Name == name);

			return resultProduct;
		}

		public async Task AddFavoriteProduct(FavoriteProduct cartProduct)
		{
			try
			{
				_context.FavoriteProducts.Add(cartProduct);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"{ex.Message}");
			}
		}

		public async Task RemoveFavoriteProduct(FavoriteProduct cartProduct)
		{
			try
			{
				_context.FavoriteProducts.Remove(cartProduct);
				await _context.SaveChangesAsync();
			}
			catch(Exception ex)
			{
				_logger.LogInformation($"{ex.Message}");
			}
		}

	}
}
