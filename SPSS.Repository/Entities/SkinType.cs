using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class SkinType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
        public bool isDelete { get; set; } = false;

        public virtual Result? Result { get; set; }
        public virtual ICollection<ProductSkinType> ProductSkinTypes { get; set; } = new List<ProductSkinType>();

    }
}
