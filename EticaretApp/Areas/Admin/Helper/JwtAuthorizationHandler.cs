using EticaretApp.Models;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net.Http.Headers;
using System.Text;

namespace EticaretApp.Areas.Admin.Helper
{
    public class JwtAuthorizationHandler : DelegatingHandler
    {
        static public string AccessToken { get; set; }
        static public string RefreshToken { get; set; }
        static public DateTime Expire { get; set; }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // JWT token'ı cookie'den veya başka bir kaynaktan al
            var accessToken = AccessToken;

            if (string.IsNullOrEmpty(AccessToken) || !TokenExpired(Expire))
            {
                AccessToken = await RefreshTokenAsync(RefreshToken);
            }
                if (!string.IsNullOrEmpty(accessToken))
            {
                // Authorization header'ına JWT token'ı ekle
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                
                
            }

            // İstekleri devam ettir
            return await base.SendAsync(request, cancellationToken);
        }
        private bool TokenExpired(DateTime expire)
        {
            if(expire < DateTime.UtcNow)
                return false;
            return true; // Örnek, burada süresini kontrol edin
        }
        private async Task<string> RefreshTokenAsync(string refreshToken)
        {
            // Refresh token endpoint'ine istek gönder
            var jsonData = JsonConvert.SerializeObject(new { RefreshToken = refreshToken });
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("https://localhost:7091/api/auth/RefreshTokenLogin", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var response2 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<TokenRoot>(response2);
                    return values.token.accessToken;
                }
            }

            return null;
        }
    }
}
