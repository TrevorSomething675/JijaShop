using JijaShop.Models.ViewModels.Abstractions;
using JijaShop.Services.Abstractions;
using JijaShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class HomeController : Controller
	{
		private readonly IProductService _productService;

		private readonly IUserViewModel _userViewModel;
		public HomeController(IProductService productService)
		{
			_productService = productService;

			_userViewModel = new UserIndexViewModel();
			_userViewModel.ProductService = productService;
		}
		public IActionResult Index()
		{
			var viewModel = _userViewModel;
			return View(viewModel);
		}
		
		public IActionResult Products()
		{
			return View();
		}

		public IActionResult Info()
		{
			return View();
		}
	}
}
