using EticaretApp.Dtos.Products;
using EticaretApp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EticaretApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientService _httpClientService;

        public ProductController(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }


        public async Task<IActionResult> Index()
        {

            var products = await _httpClientService.GetAsync<GetAllProduct>("Products"); 
            return View(products);
          
        }

        public async Task<IActionResult> GetProduct(string id)
        {
            var product = await _httpClientService.GetAsync<GetSingleProduct>($"Products/{id}");
            return View(product);

        }

    }
}
