using JijaShop.Areas.UserArea.ViewModels;
using JijaShop.Services.Abstractions;
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

		public async Task<IActionResult> Products()
		{
			var products = await _productService.GetProducts();
			var model = new UserProductsViewModel
			{
				products = products
			};

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetProductsPartial(int value = 1)
		{
			var model = await _productService.GetProducts(value);

			return PartialView("GetProductsPartial", model);
		}
    }
}