using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Response
{
    public class BlogContentResponse
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
    }
}
