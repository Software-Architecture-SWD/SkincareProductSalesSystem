using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Request
{
    public class QuestionRequest
    {
        public string QuestionDESC { get; set; } = string.Empty;
        public bool isDelete { get; set; } = false;
    }
}
