using JijaShop.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using JijaShop.Api.ViewModels;

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
            var model = new ProductsViewModel
            {
                Products = products
            };

            return View(model);
        }

        public async Task<IActionResult> IndexProduct(string productName)
        {
            var model = await _productService.GetProduct(productName);

            return View(model);
        }

        public async Task<IActionResult> IndexProductsPartial(int pageCount = 1)
        {
            var model = await _productService.GetProducts(pageCount);

            return PartialView(model);
        }
    }
}
