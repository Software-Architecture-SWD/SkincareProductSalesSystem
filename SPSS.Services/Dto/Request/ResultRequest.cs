using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Request
{
    public class ResultRequest
    {
        public int MinPoint { get; set; }
        public int MaxPoint { get; set; }
        public int SkinTypeId { get; set; }
    }
}
