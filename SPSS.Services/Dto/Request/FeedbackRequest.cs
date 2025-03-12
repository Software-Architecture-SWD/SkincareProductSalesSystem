using System.ComponentModel.DataAnnotations;

public class FeedbackRequest
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public int ProductId { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int Rating { get; set; }

    [MaxLength(250, ErrorMessage = "Comment cannot exceed 250 characters.")]
    public string? Comment { get; set; }
}
