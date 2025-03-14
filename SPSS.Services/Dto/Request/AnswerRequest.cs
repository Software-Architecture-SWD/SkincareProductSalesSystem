using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Dto.Request
{
    public class AnswerRequest
    {
        public int QuestionId { get; set; }
        public string AnswerText { get; set; } = string.Empty;
        public int Point { get; set; }
    }
}
