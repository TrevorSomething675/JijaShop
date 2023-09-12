using JijaShop.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using AutoMapper;

namespace JijaShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(MainContext context, IMapper mapper, ILogger<ProductRepository> logger) 
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Product> GetProduct(int id)
        {
            var resultProduct = await _context.Products.FirstOrDefaultAsync(prod => prod.Id == id);

            return resultProduct;
        }

        public async Task CreateNewProduct(ProductDto productDto)
        {
            try
            {
                var resultProduct = _mapper.Map<Product>(productDto);
                resultProduct.CreatedDate = DateTime.Now;
                _context.Add(resultProduct);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }

        public async Task DeleteProduct(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                _context.Remove(product);
                    
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            try
            {
                var resultProduct = _mapper.Map<Product>(productDto);
                _context.Products.Update(resultProduct);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }
    }
}
