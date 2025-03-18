using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPSS.Service.Services
{
    public interface IChatService
    {
        Task<Response> StartConversationAsync(StartChatRequest request);
        Task<List<ConversationResponse>> GetWaitingConversationsAsync();
        Task<Response> AcceptConversationAsync(int conversationId, AcceptChatRequest request);
        Task<Response> SendMessageAsync(SendMessageRequest request);
        Task<List<MessageResponse>> GetChatHistoryAsync(int conversationId);
        Task<Response> MarkMessageAsReadAsync(int messageId);
    }
}
