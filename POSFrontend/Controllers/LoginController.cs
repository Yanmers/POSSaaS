using Microsoft.AspNetCore.Mvc;
using POSFrontend.Models;
using POSFrontend.Services;

namespace POSFrontend.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
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

            var registerResponse = await _userService.RegisterAsync(model);

            if (registerResponse == null)
            {
                ModelState.AddModelError("", "Error en el registro");
                return View(model);
            }


            HttpContext.Session.SetString("Token", registerResponse.Token);
            HttpContext.Session.SetString("FullName", registerResponse.FullName);
            HttpContext.Session.SetInt32("UserId", registerResponse.UserId);

            return RedirectToAction("Index", "Login");
        }
    }
}
