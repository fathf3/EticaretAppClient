using EticaretApp.Dtos.Baskets;
using EticaretApp.Dtos.Products;
using EticaretApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;

namespace EticaretApp.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IHttpClientService _httpClientService;

        public BasketController(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken").ToString();
            _httpClientService.AddDefaultRequestHeaders(accessToken);
            var baskets = await _httpClientService.GetAsync<List<GetBasket>>("Baskets");

            return View(baskets);

        }
        public async Task<JsonResult> AddItemToBasket(string productId, int quantity = 1)
        {
            AddItemToBasket basket = new AddItemToBasket();
            basket.ProductId = productId;
            basket.Quantity = quantity;
            var accessToken = HttpContext.Session.GetString("AccessToken").ToString();
            _httpClientService.AddDefaultRequestHeaders(accessToken);
            var response = await _httpClientService.PostAsync<AddItemToBasket>("Baskets", basket);
            return Json(new { success = true, message = "Ürün sepete eklendi." });

        }
    }
}
