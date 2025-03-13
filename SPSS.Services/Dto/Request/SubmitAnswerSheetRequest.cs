using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Request
{
    public class SubmitAnswerSheetRequest
    {
        public int AnswerSheetId { get; set; }
        public List<int>? AnswerIds { get; set; }
    }
}
