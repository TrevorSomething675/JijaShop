using JijaShop.Services.Abstractions;

namespace JijaShop.Models.ViewModels.Abstractions
{
	public interface IUserViewModel
	{
		public IProductService? ProductService { get; set; }
	}
}
