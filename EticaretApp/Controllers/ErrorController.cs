using Microsoft.AspNetCore.Mvc;

namespace EticaretApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Unauthorized401()
        {
            return View();
        }
    }
}
