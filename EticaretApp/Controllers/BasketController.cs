using EticaretApp.Areas.Admin.Models;
using EticaretApp.Dtos.Baskets;
using EticaretApp.Dtos.Products;
using EticaretApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace EticaretApp.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
         private readonly HttpClient _httpClient;


        public BasketController()
        {
            _httpClient = new HttpClient();

        }
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var responseMessage = await _httpClient.GetAsync("https://localhost:7091/api/baskets");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBasket>>(jsonData);

                return View(values);
            }

            return Unauthorized();
           

        }
        public async Task<IActionResult> AddItemToBasket(string productId, int quantity=1)
        {
            Basket basket = new Basket();
            basket.ProductId = productId;
            basket.Quantity = quantity;
            var jsonData = JsonConvert.SerializeObject(basket);
           //var jsonData = JsonConvert.SerializeObject(new { usernameOrEmail = username, password = password });
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var accessToken = HttpContext.Session.GetString("AccessToken").ToString();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var responseMessage = await _httpClient.PostAsync("https://localhost:7091/api/baskets", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Basket");
            }
            return RedirectToAction("/Auth/Login");
        }
    }
}
