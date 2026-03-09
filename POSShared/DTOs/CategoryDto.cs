using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSShared.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }

    public class CreateCategory
    {
        [Required(ErrorMessage = "The name file is reuired ")]
        [MaxLength(100, ErrorMessage = "The Name Field must be at most {1} character.")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500, ErrorMessage = "The Description Field must be at most {1} character.")]
        public string Description { get; set; } = string.Empty;
    }

    public class EditCategory
    {
        [Required(ErrorMessage = "The name file is reuired ")]
        [MaxLength(100, ErrorMessage = "The Name Field must be at most {1} character.")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500, ErrorMessage = "The Description Field must be at most {1} character.")]
        public string Description { get; set; } = string.Empty;
    }
}
