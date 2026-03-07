using POSShared.Enums;
using System.ComponentModel.DataAnnotations;


namespace POSShared.DTOs
{
    public class RegisterRequest
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public Role Role { get; set; } = Role.Administrador;
    }
}
