using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Request
{
    public class BlogRequest
    {
        [ForeignKey("AppUser")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("BlogCategory")]
        public int BlogCategoryId { get; set; }

        [Required]
        [MaxLength(155)]
        public string Title { get; set; } = string.Empty;
        public int Status { get; set; }
    }
}
