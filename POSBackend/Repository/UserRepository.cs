using Microsoft.EntityFrameworkCore;
using POSBackend.Data;
using POSShared.Entities;

namespace POSBackend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PostDBContext _context;
        public UserRepository(PostDBContext context)
        {
            _context = context;
        }
        public async Task<User?> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(n => n.Email == email);
        }

        public async Task<bool> UserExistAsync(string email)
        {
            return await _context.Users.AnyAsync(n => n.Email == email);
        }
    }
}
