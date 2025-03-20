using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Response
{
    public class BlogCategoryResponse
    {
        public string BlogType { get; set; } = string.Empty;
        public bool isDelete { get; set; } = false;
    }
}
