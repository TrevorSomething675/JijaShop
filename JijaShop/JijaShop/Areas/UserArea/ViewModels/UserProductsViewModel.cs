using JijaShop.Models.DTOModels;

namespace JijaShop.Areas.UserArea.ViewModels
{
    public class UserProductsViewModel
    {
        public List<ProductDto> products { get; set; } = new List<ProductDto>();
    }
}
