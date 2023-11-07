using JijaShop.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Api.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class CartController : Controller
    {
        private readonly IProductCartService _productCartService;
        public CartController(IProductCartService productCartService)
        {
            _productCartService = productCartService;
        }
        public IActionResult Index()
        {
            return View();
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