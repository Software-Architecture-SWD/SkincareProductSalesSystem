using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Capicity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        public string Unit { get; set; } = string.Empty;
        public bool isDelete { get; set; } = false;
        public ICollection<ProductCapicity> ProductCapicities { get; set; } = new List<ProductCapicity>();
    }
}
