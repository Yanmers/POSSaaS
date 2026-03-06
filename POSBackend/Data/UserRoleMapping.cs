using System.ComponentModel.DataAnnotations;

namespace POSBackend.Data
{
    public class UserRoleMapping
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
