using Microsoft.AspNetCore.Mvc;

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
