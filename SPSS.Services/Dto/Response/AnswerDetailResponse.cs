using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Response
{
    public class AnswerDetailResponse
    {
        public int Id { get; set; }
        public int AnswerSheetId { get; set; }
        public int AnswerId { get; set; }
    }
}
