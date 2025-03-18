namespace SPSS.Service.Dto.Response
{
    public class MessageResponse
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
