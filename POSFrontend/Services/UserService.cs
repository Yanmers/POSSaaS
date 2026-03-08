using POSFrontend.Models;
using POSShared.Entities;

namespace POSFrontend.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7062/api/");
        }

        public async Task<UserViewModel?> LoginAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/login", new { UserName = username, PasswordHash = password });
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<UserViewModel>();
        }

        public async Task<bool> RegisterAsync(UserViewModel user)
        {
            var response = await _httpClient.PostAsJsonAsync("users/register", user);
            return response.IsSuccessStatusCode;
        }
    }
}
