using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services;
using SPSS.API.Hubs;

namespace SPSS.API.Controllers
{
    [ApiController]
    [Route("chats")]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService chatService;
        private readonly IHubContext<ChatHub> chatHub;
        private readonly IMapper mapper;
        private readonly ILogger<ChatsController> logger;

        public ChatsController(IChatService chatService, IHubContext<ChatHub> chatHub, IMapper mapper, ILogger<ChatsController> logger)
        {
            this.chatService = chatService;
            this.chatHub = chatHub;
            this.mapper = mapper;
            this.logger = logger;
        }

        // 1. Customer starts a conversation
        [HttpPost]
        public async Task<IActionResult> StartConversation([FromBody] StartChatRequest request)
        {
            try
            {
                logger.LogInformation("Customer {CustomerId} started a conversation.", request.CustomerId);

                var response = await chatService.StartConversationAsync(request);
                if (!response.Success)
                    return BadRequest(new { message = response.Message });

                return Ok(new { message = response.Message, data = response.Data });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while starting conversation for Customer {CustomerId}.", request.CustomerId);
                return StatusCode(500, new { message = "Error while starting the conversation." });
            }
        }

        // 2. Expert accepts a conversation
        [HttpPost("{conversationId}/accept")]
        public async Task<IActionResult> AcceptConversation(int conversationId, [FromBody] AcceptChatRequest request)
        {
            try
            {
                logger.LogInformation("Expert {ExpertId} accepted conversation {ConversationId}.", request.ExpertId, conversationId);

                var response = await chatService.AcceptConversationAsync(conversationId, request);
                if (!response.Success)
                    return BadRequest(new { message = response.Message });

                return Ok(new { message = response.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while Expert {ExpertId} accepting conversation {ConversationId}.", request.ExpertId, conversationId);
                return StatusCode(500, new { message = "Error while accepting the conversation." });
            }
        }

        // 3. Send message
        [HttpPost("{conversationId}/messages")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
        {
            try
            {
                logger.LogInformation("User {SenderId} sent a message in conversation {ConversationId}.", request.SenderId, request.ConversationId);

                var response = await chatService.SendMessageAsync(request);
                if (!response.Success)
                    return BadRequest(new { message = response.Message });

                // Notify via SignalR
                await chatHub.Clients.Group($"conversation-{request.ConversationId}")
                    .SendAsync("ReceiveMessage", new { request.SenderId, request.Message });

                return Ok(new { message = response.Message, data = response.Data });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while sending message in conversation {ConversationId}.", request.ConversationId);
                return StatusCode(500, new { message = "Error while sending the message." });
            }
        }

        // 4. Get chat history
        [HttpGet("{conversationId}/messages")]
        public async Task<IActionResult> GetChatHistory(int conversationId)
        {
            try
            {
                logger.LogInformation("Fetching chat history for conversation {ConversationId}.", conversationId);

                var messages = await chatService.GetChatHistoryAsync(conversationId);
                return Ok(new { message = "Chat history retrieved successfully.", data = messages });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while retrieving chat history for conversation {ConversationId}.", conversationId);
                return StatusCode(500, new { message = "Error while retrieving chat history." });
            }
        }

        // 5. Get waiting conversations
        [HttpGet("waiting")]
        public async Task<IActionResult> GetWaitingConversations()
        {
            try
            {
                logger.LogInformation("Fetching waiting conversations.");

                var conversations = await chatService.GetWaitingConversationsAsync();
                return Ok(new { message = "Waiting conversations retrieved successfully.", data = conversations });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while retrieving waiting conversations.");
                return StatusCode(500, new { message = "Error while retrieving waiting conversations." });
            }
        }

        // 6. Mark message as read
        [HttpPost("messages/{messageId}/read")]
        public async Task<IActionResult> MarkMessageAsRead(int messageId)
        {
            try
            {
                logger.LogInformation("Marking message {MessageId} as read.", messageId);

                var response = await chatService.MarkMessageAsReadAsync(messageId);
                if (!response.Success)
                    return BadRequest(new { message = response.Message });

                return Ok(new { message = response.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while marking message {MessageId} as read.", messageId);
                return StatusCode(500, new { message = "Error while marking message as read." });
            }
        }
    }
}
