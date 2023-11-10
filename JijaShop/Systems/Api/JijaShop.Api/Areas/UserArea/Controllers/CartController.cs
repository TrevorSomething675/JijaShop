using JijaShop.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;

namespace JijaShop.Api.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class CartController : Controller
    {
		private readonly IUserCartProductsService _userProductsService;
		public CartController(IUserCartProductsService userProductsService)
        {
            _userProductsService = userProductsService;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");

            var model = _userProductsService.GetProducts();

			return View(model);

		}

        public IActionResult AppendToCartProduct() 
        {
            return Ok();
        }

        public IActionResult DeleteCartProduct()
        {
            return Ok();
        }
    }
}