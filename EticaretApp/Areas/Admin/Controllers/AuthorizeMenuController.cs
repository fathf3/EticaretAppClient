using EticaretApp.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using EticaretApp.Dtos.Roles;

namespace EticaretApp.Areas.Admin.Controllers
{
    public class AuthorizeMenuController : Controller
    {
        private readonly HttpClient _httpClient;


        public AuthorizeMenuController()
        {
            _httpClient = new HttpClient();

        }
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");

         
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var responseMessage = await _httpClient.GetAsync("https://localhost:7091/api/applicationservices"); 
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ActionRoot>>(jsonData);

                return View(values);
            }
           
            return Unauthorized();
        }
        // Rollerin secilip atanmasi gorevi gorecek
        public async Task<IActionResult> Select(string code, string menu, string[] selectedValues)
        {
           
            EndpointToRole endpointToRole = new(selectedValues,code,menu);
            
            var jsonData = JsonConvert.SerializeObject(endpointToRole);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
           
            var responseMessage = await _httpClient.PostAsync("https://localhost:7091/api/AuthorizationEndpoints", stringContent);
          
            return Redirect("/Admin/Authorizemenu/Index");
        }
    }
}
