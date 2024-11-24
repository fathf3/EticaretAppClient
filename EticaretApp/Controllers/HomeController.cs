using EticaretApp.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EticaretApp.Controllers
{
    public class HomeController : Controller
    {

        readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7091/api/Products?page=0&size=5");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAllProduct>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
