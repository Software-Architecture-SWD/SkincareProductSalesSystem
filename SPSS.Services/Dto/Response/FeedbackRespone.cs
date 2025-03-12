using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Response
{
    public class FeedbackResponse
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int ProductId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; } = string.Empty;

        public DateTime Created_at { get; set; }

        public bool isDelete { get; set; } = false;

        public virtual AppUser? AppUser { get; set; }
        public virtual Product? Product { get; set; }
    }
}
