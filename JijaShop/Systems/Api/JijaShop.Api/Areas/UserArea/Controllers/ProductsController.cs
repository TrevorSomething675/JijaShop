using JijaShop.Api.Areas.UserArea.ViewModels;
using JijaShop.Api.Data.Models.DTOModels;
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
            var model = new UserProductsViewModel
            {
                Products = products
            };

            return View(model);
        }

        public async Task<IActionResult> IndexProduct(ProductDto productDto)
        {
            //var model = await _productService.GetProduct(productDto.Name);
            var model = await _productService.GetProducts();

            return View(model[4]);
        }

        [HttpGet]
        public async Task<IActionResult> IndexProductsPartial(int pageCount = 1)
        {
            var model = await _productService.GetProducts(pageCount);

            return PartialView("IndexProductsPartial", model);
        }
    }
}
