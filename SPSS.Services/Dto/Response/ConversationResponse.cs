namespace SPSS.Service.Dto.Response
{
    public class ConversationResponse
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string? ExpertId { get; set; } 
        public List<MessageResponse> Messages { get; set; }
    }
}
