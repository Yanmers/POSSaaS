using Microsoft.AspNetCore.Mvc;
using POSFrontend.Models;

namespace POSFrontend.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    return Ok();
        //}
    }
}
