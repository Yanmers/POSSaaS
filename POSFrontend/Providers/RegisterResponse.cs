using POSShared.Enums;
using System.ComponentModel.DataAnnotations;

namespace POSFrontend.Providers
{
    public class RegisterResponse
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}

