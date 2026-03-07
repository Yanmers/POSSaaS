using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using POSBackend.Services;
using POSShared.DTOs;

namespace POSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authservices;

        public AuthController(IAuthServices authservices)
        {
            _authservices = authservices;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AuthResponse>> Resgister(RegisterRequest request)
        {
            var response = await _authservices.RegisterAsync(request);
            if (response == null)
            {
                return BadRequest("User Already Exists");
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequest request)
        {
            var response = await _authservices.LoginAsync(request);
            if (response == null)
            {
                return Unauthorized("Invalid Credential");
            }

            return Ok(response);
        }
    }
}
