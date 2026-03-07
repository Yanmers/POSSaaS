using POSShared.DTOs;
using POSShared.Entities;

namespace POSBackend.Services
{
    public interface IAuthServices
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
    }
}



//public Task<AuthResponse> LoginAsync(LoginRequest request)
//{
//    throw new NotImplementedException();
//}

//public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
//{
//   
//}
