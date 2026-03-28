using POSFrontend.Models;
using POSFrontend.Providers;

namespace POSFrontend.Services
{
    public interface ILoginService
    {
        Task<LoginResponse?> LoginAsync(string email, string password);
        Task<RegisterResponse?> RegisterAsync(UserViewModel model);
    }
}
