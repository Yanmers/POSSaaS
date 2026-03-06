using Microsoft.EntityFrameworkCore;
using POSShared.Entities;

namespace POSBackend.Data
{
    public class PostDBContext : DbContext
    {
        public PostDBContext(DbContextOptions<PostDBContext> options) : base(options)
        {

        }


        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<RolePrivilege> RolePrivileges => Set<RolePrivilege>();
        public DbSet<UserType> UserTypes => Set<UserType>();
        public DbSet<UserRoleMapping> UserRoleMappings => Set<UserRoleMapping>();
    }
}
