using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SPSS.Repository.Enum;

namespace SPSS.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Promotion")]
        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; } = string.Empty;
        public virtual AppUser? AppUser { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public bool isDelete { get; set; } = false;

        [Required]
        public decimal TotalAmount { get; set; } = 0;

        [Required]
        public decimal OriginalTotalAmount { get; set; } = 0;

        [Required]
        public int ItemsCount { get; set; } = 0;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? PaymentDate { get; set; } = null;
        public DateTime? CompletedDate { get; set; } = null;
        public DateTime? CanceledDate { get; set; } = null;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual Payment? Payment { get; set; }


    }
}
