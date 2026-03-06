using Microsoft.EntityFrameworkCore;

namespace POSBackend.Data
{
    public class PostDBContext : DbContext
    {
        public PostDBContext(DbContextOptions<PostDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }
    }
}
