using JijaShop.Services.Abstractions;
using JijaShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class HomeController : Controller
	{
		private readonly IProductService _productService;
		public HomeController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Info()
		{
			return View();
		}

		public IActionResult Favorites()
		{
			return View();
		}

		public IActionResult Products(int value = 1)
		{
			var products = _productService.GetProducts(value).Result;

			var model = new UserProductsViewModel
			{
				products = products,
				CurrentPage = value,
				Pages = 1
			};

			return View();
		}

		[HttpGet]
		public IActionResult ProductsPartial(int value = 1)
		{
			var model = _productService.GetProducts(value).Result;

			return PartialView("ProductsPartial", model);
		}
    }
}