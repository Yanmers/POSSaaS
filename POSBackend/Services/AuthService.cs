using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using POSBackend.Repository;
using POSShared.DTOs;
using POSShared.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace POSBackend.Services
{
    public class AuthService : IAuthServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                return null!;
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return null!;
            }

            return GenerateAuthResponse(user);
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _userRepository.UserExistAsync(request.Email))
            {
                return null!;
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User
            {
                Name = request.FullName,
                UserName = request.FullName,
                Email = request.Email,
                PasswordHash = passwordHash,
                Role = request.Role
            };

            var createdUser = await _userRepository.CreateUserAsync(newUser);

            return GenerateAuthResponse(createdUser);
        }

        private AuthResponse GenerateAuthResponse(User user)
        {
            var tokenString = GenerateToken(user);
            return new AuthResponse
            {
                Token = tokenString,
                UserId = user.Id,
                Email = user.Email,
                FullName = user.Name,
                Role = user.Role.ToString()
            };
        }

        private string GenerateToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSetting");
            var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpirationMinute"]!)),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}


