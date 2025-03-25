using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SPSS.Repository.Entities;

namespace SPSS.Entities
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("BlogCategory")]
        public int BlogCategoryId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int Status { get; set; }

        public bool isDelete { get; set; } = false;

        // Navigation properties
        public virtual AppUser? AppUser { get; set; }
        public virtual BlogCategory? BlogCategory { get; set; }
        public virtual ICollection<BlogContent> Contents { get; set; } = new List<BlogContent>();
    }
}
