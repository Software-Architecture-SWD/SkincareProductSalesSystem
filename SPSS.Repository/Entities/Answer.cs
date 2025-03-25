using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(155)]
        public string AnswerText { get; set; } = string.Empty;

        [Required]
        public int Point { get; set; }
        public bool isDelete { get; set; } = false;

        // Navigation property
        public virtual Question? Question { get; set; }
    }
}
