using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
using POSFrontend.Models;
using System.Text.Json.Serialization;

namespace POSFrontend.Controllers
{

    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7062/api");
        }




        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/Users/lista");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(content);
                return View("Index", users);
            }

            return View(new List<UserViewModel>());
        }
    }
}
