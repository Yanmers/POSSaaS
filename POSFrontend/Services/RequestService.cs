
using Microsoft.JSInterop;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;


namespace POSFrontend.Services
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _js;
        public static readonly string TOKENKEY = "TOKENKEY";

        public RequestService(HttpClient httpClient, IJSRuntime js)
        {
            _httpClient = httpClient;
            _js = js;
        }

        private static JsonSerializerOptions JsonDefaultOptions => new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };

        private async Task AddAuthorizationHeaderAsync()
        {

            var token = await _js.GetFromLocalStorage(TOKENKEY);
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }


        public async Task<object> DeleteAsync(string url)
        {
            await AddAuthorizationHeaderAsync();
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<T> GetAsync<T>(string url)
        {
            await AddAuthorizationHeaderAsync();
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, JsonDefaultOptions)!;
        }

        public async Task<T> GetByIdAsync<T>(string url, int id)
        {
            await AddAuthorizationHeaderAsync();
            var requestUrl = $"{url}/{id}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, JsonDefaultOptions)!;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T model)
        {
            await AddAuthorizationHeaderAsync();
            var content = new StringContent(JsonSerializer.Serialize(model)
                , Encoding.UTF8, "appli");
            var response = await _httpClient.PostAsync(url, content);
            return response;
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string url, T model)
        {
            await AddAuthorizationHeaderAsync();
            var content = new StringContent(JsonSerializer.Serialize(model)
                , Encoding.UTF8, "Appli");
            var response = await _httpClient.PutAsync(url, content);
            return response;
        }
    }
}
