using EticaretApp.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using EticaretApp.Areas.Admin.Helper;
using EticaretApp.Dtos.Orders;

namespace EticaretApp.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        public async Task<IActionResult> Index()
        {

            CreateContext context = new();

            var responseMessage = context.ContextCreaterForGet(HttpContext, "Orders");

            if (responseMessage.Result.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<OrderRoot>(jsonData);

                return View(values);
            }

            return View();
        }
      
    }
}
