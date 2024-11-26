using EticaretApp.Dtos.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace EticaretApp.Areas.Admin.Helper
{
    public class JwtToken
    {
        readonly IHttpClientFactory _httpClientFactory;

        public JwtToken(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> GetJwtToken(string username, string password)
        {
            var client = _httpClientFactory.CreateClient("AuthorizedClient");
            //var jsonData = JsonConvert.SerializeObject(new { usernameOrEmail = "f3", password = "159357As-" });
            var jsonData = JsonConvert.SerializeObject(new { usernameOrEmail = username, password = password });
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7091/api/auth/login", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TokenRoot>(response);
                JwtAuthorizationHandler.AccessToken = values.Token.AccessToken;
                JwtAuthorizationHandler.RefreshToken = values.Token.RefreshToken;
                JwtAuthorizationHandler.Expire = values.Token.Expiration.AddHours(3);
                return values.Token.AccessToken;

            }


            return null;
        }
    }
}
