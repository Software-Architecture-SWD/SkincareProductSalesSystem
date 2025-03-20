using SPSS.Entities;
using SPSS.Repository.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Response
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int? PromotionName { get; set; }
        public string UserName { get; set; }
        public OrderStatus Status { get; set; }
        public bool isDelete { get; set; } = false;
        public decimal TotalAmount { get; set; }
        public decimal OriginalTotalAmount { get; set; }
        public int ItemsCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? CanceledDate { get; set; }
    }
}
