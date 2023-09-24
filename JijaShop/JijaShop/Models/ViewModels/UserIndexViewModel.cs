using JijaShop.Models.ViewModels.Abstractions;
using JijaShop.Services.Abstractions;

namespace JijaShop.Models.ViewModels
{
	public class UserIndexViewModel : IUserViewModel
	{
		public IProductService? ProductService { get; set; }
	}
}
