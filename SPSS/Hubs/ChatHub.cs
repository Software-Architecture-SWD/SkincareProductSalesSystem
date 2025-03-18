using Microsoft.AspNetCore.SignalR;
using SPSS.Repository.Entities;
using SPSS.Repository;
using System;
using System.Threading.Tasks;
using SPSS.Data;
using SPSS.Entities;


namespace SPSS.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly AppDbContext _context;

        public ChatHub(AppDbContext context)
        {
            _context = context;
        }

        // ✅ 1. Gửi tin nhắn từ Customer đến Expert
        public async Task SendMessage(int conversationId, string senderId, string message)
        {
            var chatMessage = new Message
            {
                ConversationId = conversationId,
                SenderId = senderId,
                Content = message,
                CreatedAt = DateTime.UtcNow
            };

            _context.Messages.Add(chatMessage);
            await _context.SaveChangesAsync();

            // ✅ Gửi tin nhắn đến tất cả người tham gia cuộc trò chuyện
            await Clients.Group($"conversation-{conversationId}").SendAsync("ReceiveMessage", new
            {
                chatMessage.Id,
                chatMessage.SenderId,
                chatMessage.Content,
                chatMessage.CreatedAt
            });
        }

        public async Task JoinConversation(int conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"conversation-{conversationId}");
        }

        public async Task MarkAsRead(int messageId)
        {
            var message = await _context.Messages.FindAsync(messageId);
            if (message != null)
            {
                message.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
