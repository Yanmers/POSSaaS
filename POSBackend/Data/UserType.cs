using System.ComponentModel.DataAnnotations;

namespace POSBackend.Data
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
