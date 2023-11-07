using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Api.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class FavoritesController : Controller
    {
        private readonly IProductFavoritesService _productFavoritesService;
        private readonly IProductService _productService;

		public FavoritesController(IProductFavoritesService productFavoritesService, IProductService productService)
        {
            _productFavoritesService = productFavoritesService;
            _productService = productService;
        }

		public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");

            var model = await _productFavoritesService.GetAllProducts();

            return View(model);
        }

        public async Task AddToFavorite(string productName)
        {
            var favoriteProduct = await _productService.GetProduct(productName);
            await _productFavoritesService.AddFavoriteProduct(favoriteProduct);
        } 
    }
}