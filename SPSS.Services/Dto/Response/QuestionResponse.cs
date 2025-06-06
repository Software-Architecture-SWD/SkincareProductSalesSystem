﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Dto.Response
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string QuestionDESC { get; set; } = string.Empty;
        public bool isDelete { get; set; } = false;
        public ICollection<AnswerResponse> Answers { get; set; } = new List<AnswerResponse>();
    }
}
