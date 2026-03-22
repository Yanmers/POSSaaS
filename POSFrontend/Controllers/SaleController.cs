using Microsoft.AspNetCore.Mvc;

namespace POSFrontend.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
