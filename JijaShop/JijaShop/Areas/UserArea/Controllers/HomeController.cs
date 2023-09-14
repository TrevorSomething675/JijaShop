using JijaShop.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class HomeController : Controller
	{
		private readonly IUserRepository _userRepository;

		public HomeController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
