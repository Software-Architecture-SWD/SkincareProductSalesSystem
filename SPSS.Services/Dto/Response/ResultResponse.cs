using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Response
{
    public class ResultResponse
    {
        public int Id { get; set; }
        public int MinPoint { get; set; }
        public int MaxPoint { get; set; }
        public int SkinTypeId { get; set; }
        public bool isDelete { get; set; } = false;
        public string? SkinTypeName { get; set; }
    }
}
