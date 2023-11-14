using JijaShop.Api.Services.Abstractions.UserProducts;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Api.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class FavoritesController : Controller
    {
        private readonly IUserFavoriteProductsService _userProductsService;
        public FavoritesController(IUserFavoriteProductsService userProductsService)
        {
            _userProductsService = userProductsService;
        }

        public async Task<IActionResult> Product(string productName)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");

            var product = await _userProductsService.GetProduct(productName);
            return PartialView(product);
        }

		public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");

            var model = await _userProductsService.GetProducts();

            return View(model);
        }

        public async Task ChangeFavoriteProduct(string productName)
        {
            if (!User.Identity.IsAuthenticated)
                return;

            var favoriteProduct = await _userProductsService.GetProduct(productName);

            if (favoriteProduct == null)
                await _userProductsService.AddProduct(productName);
            else
                await _userProductsService.RemoveProduct(productName);
		}
    }
}