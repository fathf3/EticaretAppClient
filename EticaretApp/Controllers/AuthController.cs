using EticaretApp.Areas.Admin.Helper;
using EticaretApp.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace EticaretApp.Controllers
{
    public class AuthController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUser loginUser)
        {

            JwtToken token = new(_httpClientFactory);
            var accessToken = token.GetJwtToken(loginUser.Email, loginUser.Password);
            if (!string.IsNullOrEmpty(accessToken.Result))
            {
                HttpContext.Session.SetString("AccessToken", accessToken.Result);
                return Redirect("/Home/Index");
            }
            return View();
        }
    }
}
