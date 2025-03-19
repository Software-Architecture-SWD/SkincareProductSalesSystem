public class MessageResponse
{
    public int Id { get; set; }
    public string SenderId { get; set; } = string.Empty;
    public string SenderName { get; set; } = "Unknown"; // ✅ Thêm tên người gửi
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
