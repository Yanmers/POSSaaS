using POSShared.Enums;

namespace POSShared.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiTime { get; set; }
    }
}
