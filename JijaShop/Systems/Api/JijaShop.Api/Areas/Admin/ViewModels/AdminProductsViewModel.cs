using JijaShop.Api.Data.Models.DTOModels;

namespace JijaShop.Api.Areas.Admin.ViewModels
{
    public class AdminProductsViewModel
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
