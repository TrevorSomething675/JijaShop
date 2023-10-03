using JijaShop.Models.DTOModels;

namespace JijaShop.Models.ViewModels
{
    public class UserProductsViewModel
    {
        public List<ProductDto> products { get; set; } = new List<ProductDto>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
