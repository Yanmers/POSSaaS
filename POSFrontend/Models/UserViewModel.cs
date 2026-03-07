namespace POSFrontend.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiTime { get; set; }
    }
}
