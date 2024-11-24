using EticaretApp.Dtos.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace EticaretApp.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;


        public ProductsController()
        {
            _httpClient = new HttpClient();

        }
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var responseMessage = await _httpClient.GetAsync("https://localhost:7091/api/products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAllProduct>(jsonData);
               
                return View(values);
            }

            return Unauthorized();
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(short a)
        {
            return View();
        }

    }
}
