using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Api.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class CartController : Controller
    {
        public CartController()
        {

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