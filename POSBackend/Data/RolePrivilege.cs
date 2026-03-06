using System.ComponentModel.DataAnnotations;

namespace POSBackend.Data
{
    public class RolePrivilege
    {
        [Key]
        public int Id { get; set; }
        public string RolePrivilegeName { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiTime { get; set; }
    }
}
