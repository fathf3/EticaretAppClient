using EticaretApp.Areas.Admin.Helper;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;

namespace EticaretApp.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        readonly string _url;

        public HttpClientService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _url = _configuration["BaseUrl"];
        }

        public async Task<T> GetAsync<T>(string endPoint)
        {
            
            var response = await _httpClient.GetAsync($"{_url}{endPoint}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content); // JSON'dan nesneye dönüştür
        }

        public async Task<T> PostAsync<T>(string endPoint, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_url}{endPoint}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public async Task<T> PutAsync<T>(string endPoint, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
          
            var response = await _httpClient.PutAsync($"{_url}{endPoint}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public async Task<T> DeleteAsync<T>(string endPoint)
        {
            var response = await _httpClient.DeleteAsync($"{_url}{endPoint}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public void AddDefaultRequestHeaders(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }

}
