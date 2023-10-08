using JijaShop.Areas.Admin.ViewModels;
using JijaShop.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
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

            var model = new AdminProductsViewModel()
            {
                Products = products,
            };

            return View(model);
        }

        public async Task<IActionResult> IndexAdminProductsPartial(int pageCount)
        {
            var model = await _productService.GetProducts(pageCount);

            return PartialView(model);
        }
    }
}
