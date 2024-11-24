using EticaretApp.Areas.Admin.Models;
using EticaretApp.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EticaretApp.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
           
            return View();
        }
      
    }
}
