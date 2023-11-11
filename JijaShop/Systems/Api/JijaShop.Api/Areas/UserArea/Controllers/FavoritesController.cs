using JijaShop.Api.Services.Abstractions;
using JijaShop.Api.Services.Abstractions.UserProducts;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Api.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class FavoritesController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserFavoriteProductsService _userProductsService;
        public FavoritesController(IProductService productService, IUserFavoriteProductsService userProductsService)
        {
            _userProductsService = userProductsService;
            _productService = productService;
        }

		public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");

            var model = await _userProductsService.GetProducts();

            return View(model);
        }

        public async Task AddToFavorite(string productName)
        {
            await _userProductsService.AddProduct(productName);
        }

        public async Task RemoveFormFavorite(string productName)
        {
            await _userProductsService.RemoveProduct(productName);
        }
    }
}