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

            // Usar Email y PasswordHash del modelo
            var loginResponse = await _userService.LoginAsync(model.Email, model.PasswordHash);

            if (loginResponse == null)
            {
                ModelState.AddModelError("", "Email o contraseña incorrectos");
                return View(model);
            }

            // Guardar token y datos en sesión
            HttpContext.Session.SetString("Token", loginResponse.Token);
            HttpContext.Session.SetString("FullName", loginResponse.FullName);
            HttpContext.Session.SetInt32("UserId", loginResponse.UserId);

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
