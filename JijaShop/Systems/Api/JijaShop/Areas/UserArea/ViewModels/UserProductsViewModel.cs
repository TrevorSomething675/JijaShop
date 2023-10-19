using JijaShop.Data.Models.DTOModels;

namespace JijaShop.Areas.UserArea.ViewModels
{
    public class UserProductsViewModel
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
