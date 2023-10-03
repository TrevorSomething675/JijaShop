using JijaShop.Services.Abstractions;
using JijaShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using JijaShop.Models.Entities;

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

		public IActionResult Products(int page = 1)
		{
			var pageResult = 3f;
			var pageCount = Math.Ceiling(_productService.GetProducts().Result.Count() / pageResult);

			var products = _productService.GetProducts().Result
				.Take((int)pageResult * page).ToList();

			var response = new UserProductsViewModel
			{
				products = products,
				CurrentPage = page,
				Pages = (int)pageCount
			};

			return View(response);
		} 
	}
}