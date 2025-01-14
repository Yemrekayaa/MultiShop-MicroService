using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Services
{
    public class ApiService
    {
        //private const string CatalogUrl = " https://localhost:7070";
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> RequestAsync<T>(HttpMethod method, string apiUrl, T? data = null) where T : class
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(method, apiUrl);

            if (data != null)
            {
                var jsonData = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            }

            return await client.SendAsync(request);
        }

        public async Task<TResult> GetAsync<TResult>(string apiUrl)
        {
            var response = await RequestAsync<object>(HttpMethod.Get, apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(jsonData);
        }
    }
}
