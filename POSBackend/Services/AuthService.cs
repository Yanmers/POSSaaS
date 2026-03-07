using POSBackend.Repository;
using POSShared.DTOs;
using POSShared.Entities;
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

        public Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _userRepository.UserExistAsync(request.Email))
            {
                return null; //User Already Exits.
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User
            {
                Name = request.FullName,
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
            var jwtSetting = _configuration.GetSection("JwtSetting");
            var key = Encoding.UTF8.GetBytes(jwtSetting["SecretKey"]!);
        }

    }
}


