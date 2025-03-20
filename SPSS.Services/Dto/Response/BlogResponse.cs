using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Response
{
    public class BlogResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int BlogCategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Status { get; set; }
        public bool isDelete { get; set; } = false;
        public ICollection<BlogContentResponse> Contents { get; set; } = new List<BlogContentResponse>();
    }
}
