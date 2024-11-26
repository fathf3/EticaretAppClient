using EticaretApp.Dtos.Baskets;
using EticaretApp.Dtos.Products;
using EticaretApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;

namespace EticaretApp.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IHttpClientService _httpClientService;

        public ProductsController(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken").ToString();
            _httpClientService.AddDefaultRequestHeaders(accessToken);
            var products = await _httpClientService.GetAsync<GetAllProduct>("Products");
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProduct createProduct)
        {

            var accessToken = HttpContext.Session.GetString("AccessToken").ToString();
            _httpClientService.AddDefaultRequestHeaders(accessToken);
            var response = await _httpClientService.PostAsync<CreateProduct>("Products", createProduct);
           
            return RedirectToAction("Index");



        }

    }
}
