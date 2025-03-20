namespace SPSS.Service.Dto.Request
{
    public class SendMessageRequest
    {
        public int ConversationId { get; set; } 
        public string SenderId { get; set; } 
        public string Message { get; set; } 
    }
}
