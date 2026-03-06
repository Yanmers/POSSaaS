using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using POSBackend.Data;
using POSBackend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace POSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AllowAnonymous]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly PostDBContext _PostDBContext;
        private IConfiguration _config;

        public LoginController(PostDBContext PostDBContext, IConfiguration config)
        {
            _PostDBContext = PostDBContext;
            _config = config;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var user = _PostDBContext.Users.ToList();

            return Ok(user);
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public ActionResult<User> CreateUser([FromBody] UserDTO model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest($"Validar {model}, not fount");
        //        }


        //        User user = new User
        //        {
        //            UserName = model.UserName,
        //            Password = model.Password,
        //            PasswordSalt = model.PasswordSalt,
        //            UserType = model.UserType,
        //            IsActive = true,
        //            IsDelete = false,
        //            CreateDate = DateTime.Now


        //        };

        //        if (user == null)
        //        {
        //            return NotFound($"Usuario {user}, Invalido");
        //        }

        //        _PostDBContext.Add(user);
        //        _PostDBContext.SaveChanges();

        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest($"Validar Error {ex}");
        //    }
        //}

        [HttpPost]
        public ActionResult<User> Login([FromBody] UserDTO model)
        {
            // 1. Validar usuario contra base de datos
            if (!ModelState.IsValid)
            {
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: creds
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return Ok(Unauthorized());
        }


    }
}
