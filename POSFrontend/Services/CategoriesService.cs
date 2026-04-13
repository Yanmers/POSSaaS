using POSShared.DTOs;
using POSShared.Entities;
using System.Net.Http;
using POSFrontend.Models;
using POSFrontend.Providers;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace POSFrontend.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly HttpClient _httpClient;

        public CategoriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7062/");
        }


        public async Task<CategoryResponse?> CreateAsync(string name, string description)
        {
            var payload = new
            {
                Name = name,
                Description = description
            };

            var response = await _httpClient.PostAsJsonAsync("api/Categoris", payload);

            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<CategoryResponse>();
        }

        public Task<CategoryResponse?> ReadAsync(CategoriesViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
