using JijaShop.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Api.Areas.UserArea.Controllers
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

            return View(products);
        }

        public async Task<IActionResult> Product(string productName)
        {
            var model = await _productService.GetProduct(productName);

            return View(model);
        }

        public async Task<IActionResult> ProductsPartial(int pageCount = 1)
        {

            var model = await _productService.GetProducts(pageCount);

            return PartialView("ProductsPartial/ProductsPartial", model);
        }
    }
}
