using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BrandName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Country { get; set; }

        public bool isDelete { get; set; } = false;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
