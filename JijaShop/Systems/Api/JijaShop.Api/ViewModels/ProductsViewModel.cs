using JijaShop.Api.Data.Models.DTOModels;

namespace JijaShop.Api.ViewModels
{
    public class ProductsViewModel
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
