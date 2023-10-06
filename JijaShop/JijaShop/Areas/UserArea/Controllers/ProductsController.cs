using JijaShop.Areas.UserArea.ViewModels;
using JijaShop.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            var model = new UserProductsViewModel
            {
                products = products
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> IndexProductsPartial(int value = 1)
        {
            var model = await _productService.GetProducts(value);

            return PartialView("IndexProductsPartial", model);
        }
    }
}
