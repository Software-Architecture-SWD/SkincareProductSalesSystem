using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Response
{
    public class BrandResponse
    {
        public string BrandName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Country { get; set; }

        public bool isDelete { get; set; } = false;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
