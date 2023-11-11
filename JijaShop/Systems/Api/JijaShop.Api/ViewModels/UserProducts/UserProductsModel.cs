using JijaShop.Api.Data.Models.DTOModels;

namespace JijaShop.Api.ViewModels.UserProducts
{
	public class UserProductsModel
	{
		public List<ProductDto>? FavoriteProducts { get; set; }
		public List<ProductDto>? CartProducts { get; set; }
	}
}
