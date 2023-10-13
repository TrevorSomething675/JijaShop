﻿using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class HomeController : Controller
	{
		public async Task<IActionResult> Index()
		{
			return View();
		}

		public async Task<IActionResult> Favorites()
		{
			return View();
		}
    }
}