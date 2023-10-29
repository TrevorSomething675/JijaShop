using JijaShop.Api.Areas.Admin.ViewModels;
using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Api.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            try
            {
                await _productService.CreateNewProduct(productDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest("Ошибка при добавлении продукта");
            }

        }

        public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        {
            try
            {
                await _productService.UpdateProduct(productDto);
                return Ok();
            }
            catch
            {
                return BadRequest("Не удалось обновить продукт");
            }
        }

        public async Task<IActionResult> DeleteProduct(ProductDto productDto)
        {
            try
            {
                await _productService.DeleteProduct(productDto);
                return Ok();
            }
            catch
            {
                return BadRequest("Не удалось удалить продукт");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();

            var model = new AdminProductsViewModel()
            {
                Products = products,
            };

            return View(model);
        }

        public async Task<IActionResult> IndexAdminProductsPartial(int pageCount)
        {
            var model = await _productService.GetProducts(pageCount);

            return PartialView(model);
        }
    }
}
