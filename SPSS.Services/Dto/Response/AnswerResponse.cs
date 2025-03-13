using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Dto.Response
{
    public class AnswerResponse
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; } = string.Empty;
        public int Point { get; set; }
        public bool isDelete { get; set; } = false;
    }
}
