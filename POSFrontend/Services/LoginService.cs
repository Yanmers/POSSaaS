using Microsoft.AspNetCore.Identity.Data;
using NuGet.Protocol.Plugins;
using POSFrontend.Models;
using POSFrontend.Providers;
using POSShared.Entities;
using POSShared.Enums;

namespace POSFrontend.Services
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7062/");
        }

        public async Task<LoginResponse?> LoginAsync(string email, string password)
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

        public async Task<RegisterResponse?> RegisterAsync(UserViewModel model)
        {
            var payload = new
            {
                fullName = model.Name,
                email = model.Email,
                password = model.PasswordHash,
                confirmPassword = model.PasswordHash
            };

            var response = await _httpClient.PostAsJsonAsync("api/auth/register", payload);

            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<RegisterResponse>();
        }
    }
}


