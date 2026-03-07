using Microsoft.AspNetCore.Mvc;

namespace POSFrontend.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
