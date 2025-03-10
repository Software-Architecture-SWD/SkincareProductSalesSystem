using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class BlogCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BlogType { get; set; } = string.Empty;
        public bool isDelete { get; set; } = false;
    }
}
