using System.Net.Http.Headers;
using System.Text;

namespace EticaretApp.Areas.Admin.Helper
{
    public  class CreateContext
    {
        private readonly HttpClient _httpClient;
        public CreateContext()
        {
            _httpClient = new HttpClient();

        }
        public async Task<HttpResponseMessage> ContextCreaterForGet(HttpContext httpContext, string uri)
        {
            var accessToken = httpContext.Session.GetString("AccessToken").ToString();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var responseMessage = await _httpClient.GetAsync($"https://localhost:7091/api/{uri}");
            return responseMessage;
        }
      
    }
}
