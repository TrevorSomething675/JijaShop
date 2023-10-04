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

		[HttpGet]
		public IActionResult Products(int page = 1)
		{
			var products = _productService.GetProducts(page).Result;

			var model = new UserProductsViewModel
			{
				products = products,
				CurrentPage = page,
				Pages = 1
			};

			return View(model);
		}

        [HttpPost]
        public IActionResult UpdateProductIncrement(int value)
        {
            // Обрабатываем пришедшие данные
            // При успешной обработке возвращаем успешный статус
            return Json(new { success = true });
        }
    }
}