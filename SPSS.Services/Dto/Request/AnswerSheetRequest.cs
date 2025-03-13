using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Request
{
    public class AnswerSheetRequest
    {
        public string UserId { get; set; } = string.Empty;
        public int TotalPoint { get; set; }

    }
}
