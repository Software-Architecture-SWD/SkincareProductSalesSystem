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

        // ✅ 1. API Customer bắt đầu cuộc trò chuyện
        [HttpPost("start")]
        public async Task<IActionResult> StartConversation([FromBody] StartChatRequest request)
        {
            try
            {
                _logger.LogInformation("Customer {CustomerId} bắt đầu cuộc trò chuyện.", request.CustomerId);

                var response = await _chatService.StartConversationAsync(request);
                if (!response.Success) return BadRequest(new { message = response.Message });

                return Ok(new { message = response.Message, data = response.Data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi Customer {CustomerId} bắt đầu cuộc trò chuyện.", request.CustomerId);
                return StatusCode(500, new { message = "Lỗi khi bắt đầu cuộc trò chuyện.", error = ex.Message });
            }
        }

        // ✅ 2. API Expert nhận cuộc trò chuyện
        [HttpPost("accept/{conversationId}")]
        public async Task<IActionResult> AcceptConversation(int conversationId, [FromBody] AcceptChatRequest request)
        {
            try
            {
                _logger.LogInformation("Expert {ExpertId} nhận cuộc trò chuyện ID {ConversationId}", request.ExpertId, conversationId);

                var response = await _chatService.AcceptConversationAsync(conversationId, request);
                if (!response.Success) return BadRequest(new { message = response.Message });

                return Ok(new { message = response.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi Expert {ExpertId} nhận cuộc trò chuyện ID {ConversationId}.", request.ExpertId, conversationId);
                return StatusCode(500, new { message = "Lỗi khi nhận cuộc trò chuyện.", error = ex.Message });
            }
        }

        // ✅ 3. API Gửi tin nhắn
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
        {
            try
            {
                _logger.LogInformation("User {SenderId} gửi tin nhắn trong cuộc trò chuyện ID {ConversationId}.", request.SenderId, request.ConversationId);

                var response = await _chatService.SendMessageAsync(request);
                if (!response.Success) return BadRequest(new { message = response.Message });

                // 🔥 Thông báo tin nhắn qua SignalR
                await _chatHub.Clients.Group($"conversation-{request.ConversationId}")
                    .SendAsync("ReceiveMessage", new { request.SenderId, request.Message });

                return Ok(new { message = response.Message, data = response.Data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gửi tin nhắn trong cuộc trò chuyện ID {ConversationId}.", request.ConversationId);
                return StatusCode(500, new { message = "Lỗi khi gửi tin nhắn.", error = ex.Message });
            }
        }

        // ✅ 4. API Lấy danh sách tin nhắn của một cuộc trò chuyện
        [HttpGet("history/{conversationId}")]
        public async Task<IActionResult> GetChatHistory(int conversationId)
        {
            try
            {
                _logger.LogInformation("Fetching chat history for conversation ID {ConversationId}.", conversationId);

                var messages = await _chatService.GetChatHistoryAsync(conversationId);
                return Ok(new { message = "Lấy lịch sử tin nhắn thành công.", data = messages });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy lịch sử tin nhắn của cuộc trò chuyện ID {ConversationId}.", conversationId);
                return StatusCode(500, new { message = "Lỗi khi lấy lịch sử tin nhắn.", error = ex.Message });
            }
        }

        // ✅ 5. API Lấy danh sách cuộc trò chuyện đang chờ Expert
        [HttpGet("waiting")]
        public async Task<IActionResult> GetWaitingConversations()
        {
            try
            {
                _logger.LogInformation("Fetching waiting conversations.");
                var conversations = await _chatService.GetWaitingConversationsAsync();
                return Ok(new { message = "Lấy danh sách cuộc trò chuyện thành công.", data = conversations });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách cuộc trò chuyện đang chờ.");
                return StatusCode(500, new { message = "Lỗi khi lấy danh sách cuộc trò chuyện.", error = ex.Message });
            }
        }

        // ✅ 6. API Đánh dấu tin nhắn đã đọc
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
                _logger.LogError(ex, "Lỗi khi đánh dấu tin nhắn ID {MessageId} là đã đọc.", messageId);
                return StatusCode(500, new { message = "Lỗi khi đánh dấu tin nhắn.", error = ex.Message });
            }
        }
    }
}
