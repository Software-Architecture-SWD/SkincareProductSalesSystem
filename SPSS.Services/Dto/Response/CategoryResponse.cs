﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Response
{
    public class CategoryResponse
    {
        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }
        public bool isDelete { get; set; } = false;
    }
}
