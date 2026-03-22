using Microsoft.AspNetCore.Mvc;

namespace POSFrontend.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
