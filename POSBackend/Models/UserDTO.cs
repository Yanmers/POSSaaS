using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POSBackend.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string PasswordSalt { get; set; } = string.Empty;
        public int UserType { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiTime { get; set; }
    }
}
