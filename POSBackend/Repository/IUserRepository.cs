using POSShared.Entities;

namespace POSBackend.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> CreateUserAsync(User user);
        Task<bool> UserExistAsync(string email);
    }
}
