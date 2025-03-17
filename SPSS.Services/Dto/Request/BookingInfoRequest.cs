using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Request
{
    public class BookingInfoRequest
    {

        [Required]
        [ForeignKey("Customer")]
        public string CustomerId { get; set; } = string.Empty;
        [Required]
        [ForeignKey("Expert")]
        public string ExpertId { get; set; } = string.Empty;
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public DateTime Start_time { get; set; }

        [Required]
        public DateTime End_time { get; set; }

        [MaxLength(500)]
        public string? Special_requests { get; set; }

        [Required]
        public int Status { get; set; } // Có thể sử dụng Enum
    }
}
