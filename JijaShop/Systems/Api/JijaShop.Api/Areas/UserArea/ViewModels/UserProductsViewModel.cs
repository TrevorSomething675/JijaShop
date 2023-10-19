using JijaShop.Api.Data.Models.DTOModels;

namespace JijaShop.Api.Areas.UserArea.ViewModels
{
    public class UserProductsViewModel
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
