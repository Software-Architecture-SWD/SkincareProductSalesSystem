using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Entities
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("AppUser")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(250)]
        public string Comment { get; set; } = string.Empty;

        [Required]
        public DateTime Created_at { get; set; } = DateTime.UtcNow;

        public bool isDelete { get; set; } = false;

        // Navigation properties
        public virtual AppUser? AppUser { get; set; }
        public virtual Product? Product { get; set; }
    }
}
