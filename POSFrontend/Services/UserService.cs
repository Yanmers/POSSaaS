using NuGet.Protocol.Plugins;
using POSFrontend.Models;
using POSFrontend.Providers;
using POSShared.Entities;

namespace POSFrontend.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7062");
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            var payload = new
            {
                Email = email,
                Password = password
            };


            var response = await _httpClient.PostAsJsonAsync("api/auth/login", payload);

            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }



        public async Task<bool> RegisterAsync(UserViewModel user)
        {
            var response = await _httpClient.PostAsJsonAsync("users/register", user);
            return response.IsSuccessStatusCode;
        }
    }
}
