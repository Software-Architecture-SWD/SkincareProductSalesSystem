using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services;
using SPSS.API.Hubs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPSS.API.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IHubContext<ChatHub> _chatHub;
        private readonly IMapper _mapper;
        private readonly ILogger<ChatController> _logger;

        public ChatController(IChatService chatService, IHubContext<ChatHub> chatHub, IMapper mapper, ILogger<ChatController> logger)
        {
            _chatService = chatService;
            _chatHub = chatHub;
            _mapper = mapper;
            _logger = logger;
        }

        // ✅ 1. API Customer starts a conversation
        [HttpPost("start")]
        public async Task<IActionResult> StartConversation([FromBody] StartChatRequest request)
        {
            try
            {
                _logger.LogInformation("Customer {CustomerId} started a conversation.", request.CustomerId);

                var response = await _chatService.StartConversationAsync(request);
                if (!response.Success) return BadRequest(new { message = response.Message });

                return Ok(new { message = response.Message, data = response.Data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while Customer {CustomerId} started a conversation.", request.CustomerId);
                return StatusCode(500, new { message = "Error while starting the conversation." });
            }
        }

        // ✅ 2. API Expert accepts a conversation
        [HttpPost("accept/{conversationId}")]
        public async Task<IActionResult> AcceptConversation(int conversationId, [FromBody] AcceptChatRequest request)
        {
            try
            {
                _logger.LogInformation("Expert {ExpertId} accepted conversation ID {ConversationId}", request.ExpertId, conversationId);

                var response = await _chatService.AcceptConversationAsync(conversationId, request);
                if (!response.Success) return BadRequest(new { message = response.Message });

                return Ok(new { message = response.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while Expert {ExpertId} accepting conversation ID {ConversationId}.", request.ExpertId, conversationId);
                return StatusCode(500, new { message = "Error while accepting the conversation." });
            }
        }

        // ✅ 3. API Send message
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
        {
            try
            {
                _logger.LogInformation("User {SenderId} sent a message in conversation ID {ConversationId}.", request.SenderId, request.ConversationId);

                var response = await _chatService.SendMessageAsync(request);
                if (!response.Success) return BadRequest(new { message = response.Message });

                // 🔥 Notify via SignalR
                await _chatHub.Clients.Group($"conversation-{request.ConversationId}")
                    .SendAsync("ReceiveMessage", new { request.SenderId, request.Message });

                return Ok(new { message = response.Message, data = response.Data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while sending message in conversation ID {ConversationId}.", request.ConversationId);
                return StatusCode(500, new { message = "Error while sending the message." });
            }
        }

        // ✅ 4. API Get chat history
        [HttpGet("history/{conversationId}")]
        public async Task<IActionResult> GetChatHistory(int conversationId)
        {
            try
            {
                _logger.LogInformation("Fetching chat history for conversation ID {ConversationId}.", conversationId);

                var messages = await _chatService.GetChatHistoryAsync(conversationId);
                return Ok(new { message = "Chat history retrieved successfully.", data = messages });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching chat history for conversation ID {ConversationId}.", conversationId);
                return StatusCode(500, new { message = "Error while retrieving chat history." });
            }
        }

        // ✅ 5. API Get waiting conversations
        [HttpGet("waiting")]
        public async Task<IActionResult> GetWaitingConversations()
        {
            try
            {
                _logger.LogInformation("Fetching waiting conversations.");
                var conversations = await _chatService.GetWaitingConversationsAsync();
                return Ok(new { message = "Waiting conversations retrieved successfully.", data = conversations });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching waiting conversations.");
                return StatusCode(500, new { message = "Error while retrieving waiting conversations." });
            }
        }

        // ✅ 6. API Mark message as read
        [HttpPost("read/{messageId}")]
        public async Task<IActionResult> MarkMessageAsRead(int messageId)
        {
            try
            {
                _logger.LogInformation("Marking message ID {MessageId} as read.", messageId);

                var response = await _chatService.MarkMessageAsReadAsync(messageId);
                if (!response.Success) return BadRequest(new { message = response.Message });

                return Ok(new { message = response.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while marking message ID {MessageId} as read.", messageId);
                return StatusCode(500, new { message = "Error while marking the message as read." });
            }
        }
    }
}
