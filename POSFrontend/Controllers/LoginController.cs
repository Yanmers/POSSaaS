using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using POSFrontend.Models;
using POSFrontend.Services;

namespace POSFrontend.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _conf;
        private readonly UserService _userService;
        public LoginController(IConfiguration conf, UserService userService)
        {
            _conf = conf;
            _userService = userService;
        }


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var user = await _userService.LoginAsync(model.UserName, model.PasswordHash);

            if (user == null)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                return View(model);
            }


            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.RegisterAsync(model);

            if (!result)
            {
                ModelState.AddModelError("", "No se pudo registrar el usuario");
                return View(model);
            }

            return RedirectToAction("Index", "Login");
        }

    }
}
