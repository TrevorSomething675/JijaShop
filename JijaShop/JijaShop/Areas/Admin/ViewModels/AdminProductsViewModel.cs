using JijaShop.Models.DTOModels;

namespace JijaShop.Areas.Admin.ViewModels
{
    public class AdminProductsViewModel
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
