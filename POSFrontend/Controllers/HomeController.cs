using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using POSFrontend.Models;

namespace POSFrontend.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
