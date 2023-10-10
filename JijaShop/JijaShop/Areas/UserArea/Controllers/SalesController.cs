using JijaShop.Areas.UserArea.ViewModels;
using JijaShop.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class SalesController : Controller
    {
        private readonly IProductService _productService;

        public SalesController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            var model = new UserProductsViewModel()
            {
                Products = products
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> IndexSalesProductsPartial(int pageCount = 1)
        {
            var model = await _productService.GetProducts(pageCount);

            return PartialView("IndexSalesProductsPartial", model);
        }
    }
}