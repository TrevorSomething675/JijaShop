using JijaShop.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using JijaShop.Api.ViewModels;

namespace JijaShop.Api.Views.Shared.Components.OwlCarousel
{
    public class OwlCarousel : ViewComponent
    {
        private readonly IProductService _productService;
        public OwlCarousel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new OwlCarouselViewModel
            {
                Products = await _productService.GetProducts(1)
            };

            return View(model);
        }
    }
}
