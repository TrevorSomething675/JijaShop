using JijaShop.Api.Services.Abstractions.UserProducts;
using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Api.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserProductsService _userProductsService;

        public ProductsController(IProductService productService, IUserProductsService userProductsService)
        {
            _userProductsService = userProductsService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = new List<ProductDto>();

            if (!User.Identity.IsAuthenticated)
                products = await _productService.GetProducts();
            else
                products = await _userProductsService.GetProducts();

            return View(products);
        }

        public async Task<IActionResult> Product(string productName)
        {
            var product = new ProductDto();

			if (!User.Identity.IsAuthenticated)
				product = await _productService.GetProduct(productName);
			else
				product = await _userProductsService.GetProduct(productName);

			return View(product);
        }

        public async Task<IActionResult> ProductsPartial(int pageCount = 1)
        {
			var products = new List<ProductDto>();

			if (!User.Identity.IsAuthenticated)
				products = await _productService.GetProducts(pageCount);
			else
				products = await _userProductsService.GetProducts();

			return PartialView("ProductsPartial/ProductsPartial", products);
        }
    }
}