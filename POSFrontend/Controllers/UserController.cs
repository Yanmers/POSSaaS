using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
using POSFrontend.Models;
using System.Text.Json.Serialization;

namespace POSFrontend.Controllers
{

    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
