using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSFrontend.Models;
using POSFrontend.Services;
using POSShared.Entities;

namespace POSFrontend.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoriesService _category;

        public CategoriesController(CategoriesService category)
        {
            _category = category;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CategoriesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var categoryResponse = await _category.ReadAsync(model.Name, model.Description);


            if (categoryResponse == null)
            {
                ModelState.AddModelError("", "Name o Description incorrectos");
                return View(model);
            }


            HttpContext.Session.SetString("Token", categoryResponse.Token);
            HttpContext.Session.SetString("Name", categoryResponse.Name);
            HttpContext.Session.SetString("Description", categoryResponse.Description);

            return RedirectToAction("Index", "Categories");

        }



    }
}
