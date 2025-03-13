using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Request
{
    public class BrandRequest
    {
        [Required]
        public string BrandName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Country { get; set; }
    }
}
