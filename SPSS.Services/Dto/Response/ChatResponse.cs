namespace SPSS.Service.Dto.Response
{
    public class ChatResponse
    {
        public int ConversationId { get; set; }
        public string CustomerId { get; set; }
        public string? ExpertId { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
