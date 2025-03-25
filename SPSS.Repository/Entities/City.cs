using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public bool isDelete { get; set; } = false;
    }
}
