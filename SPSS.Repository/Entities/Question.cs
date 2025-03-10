using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string QuestionDESC { get; set; } = string.Empty;
        public bool isDelete { get; set; } = false;
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    }
}
