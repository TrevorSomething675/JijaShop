using JijaShop.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using AutoMapper;

namespace JijaShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(MainContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> GetProduct(int id)
        {
            var resultProduct = await _context.Products.FirstOrDefaultAsync(prod => prod.Id == id);

            return resultProduct;
        }

        public async Task CreateNewProduct(ProductDto productDto)
        {
            var resultProduct = _mapper.Map<Product>(productDto);
            resultProduct.CreatedDate = DateTime.Now;
            _context.Add(resultProduct);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var resultProduct = _mapper.Map<Product>(productDto);
            _context.Products.Update(resultProduct);

            await _context.SaveChangesAsync();
        }
    }
}
