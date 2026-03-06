using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSBackend.Data;
using POSBackend.Models;
using System.Runtime.CompilerServices;

namespace POSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PostDBContext _PostDBContext;

        public LoginController(PostDBContext PostDBContext)
        {
            _PostDBContext = PostDBContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var user = _PostDBContext.Users.ToList();

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<User> CreateUser([FromBody] UserDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Validar {model}, not fount");
                }


                User user = new User
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    PasswordSalt = model.PasswordSalt,
                    UserType = model.UserType,
                    IsActive = true,
                    IsDelete = false,
                    CreateDate = DateTime.Now


                };

                if (user == null)
                {
                    return NotFound($"Usuario {user}, Invalido");
                }

                _PostDBContext.Add(user);
                _PostDBContext.SaveChanges();

                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest($"Validar Error {ex}");
            }
        }


    }
}
