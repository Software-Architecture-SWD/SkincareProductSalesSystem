using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Request
{
    public class BlogCategoryRequest
    {
        [Required]
        public string BlogType { get; set; } = string.Empty;
    }
}
