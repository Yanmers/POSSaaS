using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using POSFrontend.Models;

namespace POSFrontend.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _conf;
        public LoginController(IConfiguration conf)
        {
            _conf = conf;
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
        public IActionResult Index([FromBody] UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Login");
            }

            UserViewModel userViewModel = new UserViewModel
            {
                Name = model.Name,
                PasswordHash = model.PasswordHash

            };
            if (userViewModel == null)
            {
                return NotFound($"favor validar {userViewModel} es incorrecto ");
            }
            else
            {
                //Guardar userViewModel en la base de datos.

                return RedirectToAction("Index", "Home");
            }



        }

        [HttpPost]
        public IActionResult Register([FromBody] UserViewModel model)
        {
            if (model == null)
            {
                return BadRequest($"Favor validar{model}");
            }

            UserViewModel userViewModel = new UserViewModel
            {
                Name = model.Name,
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = model.PasswordHash

            };
            if (userViewModel == null)
            {
                return NotFound($"favor validar {userViewModel} es incorrecto ");
            }
            else
            {
                //Guardar userViewModel en la base de datos.

                return RedirectToAction("Index", "LoginController");
            }



        }
    }
}
