using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.Repositories;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSS.Service.Services
{
    public class ChatService : IChatService
    {
        private readonly IConversationRepository _conversationRepo;
        private readonly IMessageRepository _messageRepo;
        private readonly ILogger<ChatService> _logger;

        public ChatService(IConversationRepository conversationRepo, IMessageRepository messageRepo, ILogger<ChatService> logger)
        {
            _conversationRepo = conversationRepo;
            _messageRepo = messageRepo;
            _logger = logger;
        }

        // ✅ 1. Bắt đầu cuộc trò chuyện
        public async Task<Response> StartConversationAsync(StartChatRequest request)
        {
            try
            {
                _logger.LogInformation("Customer {CustomerId} bắt đầu cuộc trò chuyện.", request.CustomerId);

                var conversation = await _conversationRepo.GetByCustomerIdAsync(request.CustomerId);

                if (conversation == null)
                {
                    conversation = new Conversation
                    {
                        UserId1 = request.CustomerId,
                        UserId2 = null!,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _conversationRepo.AddAsync(conversation);

                    conversation = await _conversationRepo.GetByCustomerIdAsync(request.CustomerId);
                }

                if (conversation == null || conversation.Id == 0)
                {
                    _logger.LogWarning("Lỗi khi tạo cuộc trò chuyện cho Customer {CustomerId}", request.CustomerId);
                    return new Response { Success = false, Message = "Lỗi khi tạo cuộc trò chuyện.", Data = null };
                }

                var message = new Message
                {
                    ConversationId = conversation.Id,
                    SenderId = request.CustomerId,
                    Content = request.Message
                };
                await _messageRepo.AddAsync(message);

                _logger.LogInformation("Cuộc trò chuyện ID {ConversationId} đã được tạo.", conversation.Id);
                return new Response { Success = true, Message = "Cuộc trò chuyện đã được tạo.", Data = conversation.Id };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tạo cuộc trò chuyện cho Customer {CustomerId}.", request.CustomerId);
                throw;
            }
        }

        // ✅ 2. Lấy danh sách cuộc trò chuyện đang chờ Expert
        public async Task<List<ConversationResponse>> GetWaitingConversationsAsync()
        {
            try
            {
                _logger.LogInformation("Fetching waiting conversations.");
                var conversations = await _conversationRepo.GetWaitingConversationsAsync();
                return conversations.Select(c => new ConversationResponse
                {
                    Id = c.Id,
                    CustomerId = c.UserId1,
                    ExpertId = c.UserId2
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách cuộc trò chuyện đang chờ.");
                throw;
            }
        }

        // ✅ 3. Expert nhận cuộc trò chuyện
        public async Task<Response> AcceptConversationAsync(int conversationId, AcceptChatRequest request)
        {
            try
            {
                _logger.LogInformation("Expert {ExpertId} nhận cuộc trò chuyện ID {ConversationId}", request.ExpertId, conversationId);

                var conversation = await _conversationRepo.GetByIdAsync(conversationId);
                if (conversation == null || conversation.UserId2 != null)
                {
                    _logger.LogWarning("Cuộc trò chuyện ID {ConversationId} đã được nhận hoặc không tồn tại.", conversationId);
                    return new Response { Success = false, Message = "Cuộc trò chuyện đã được nhận." };
                }

                conversation.UserId2 = request.ExpertId;
                await _conversationRepo.UpdateAsync(conversation);
                _logger.LogInformation("Expert {ExpertId} đã nhận cuộc trò chuyện ID {ConversationId}.", request.ExpertId, conversationId);
                return new Response { Success = true, Message = "Expert đã nhận cuộc trò chuyện." };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi Expert {ExpertId} nhận cuộc trò chuyện ID {ConversationId}.", request.ExpertId, conversationId);
                throw;
            }
        }

        // ✅ 4. Gửi tin nhắn
        public async Task<Response> SendMessageAsync(SendMessageRequest request)
        {
            try
            {
                _logger.LogInformation("User {SenderId} gửi tin nhắn trong cuộc trò chuyện ID {ConversationId}.", request.SenderId, request.ConversationId);

                var message = new Message
                {
                    ConversationId = request.ConversationId,
                    SenderId = request.SenderId,
                    Content = request.Message
                };
                await _messageRepo.AddAsync(message);

                _logger.LogInformation("Tin nhắn đã được gửi thành công.");
                return new Response { Success = true, Message = "Tin nhắn đã được gửi.", Data = message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gửi tin nhắn trong cuộc trò chuyện ID {ConversationId}.", request.ConversationId);
                throw;
            }
        }

        // ✅ 5. Lấy lịch sử tin nhắn
        public async Task<List<MessageResponse>> GetChatHistoryAsync(int conversationId)
        {
            try
            {
                _logger.LogInformation("Fetching chat history for conversation ID {ConversationId}.", conversationId);

                var messages = await _messageRepo.GetMessagesByConversationIdAsync(conversationId);
                return messages.Select(m => new MessageResponse
                {
                    Id = m.Id,
                    SenderId = m.SenderId,
                    Content = m.Content,
                    CreatedAt = m.CreatedAt
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy lịch sử tin nhắn của cuộc trò chuyện ID {ConversationId}.", conversationId);
                throw;
            }
        }

        // ✅ 6. Đánh dấu tin nhắn đã đọc
        public async Task<Response> MarkMessageAsReadAsync(int messageId)
        {
            try
            {
                _logger.LogInformation("Marking message ID {MessageId} as read.", messageId);

                var message = await _messageRepo.GetByIdAsync(messageId);
                if (message == null)
                {
                    _logger.LogWarning("Không tìm thấy tin nhắn ID {MessageId}.", messageId);
                    return new Response { Success = false, Message = "Không tìm thấy tin nhắn." };
                }

                message.IsDeleted = true;
                await _messageRepo.UpdateAsync(message);

                _logger.LogInformation("Tin nhắn ID {MessageId} đã được đánh dấu là đã đọc.", messageId);
                return new Response { Success = true, Message = "Tin nhắn đã được đánh dấu là đã đọc." };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi đánh dấu tin nhắn ID {MessageId} là đã đọc.", messageId);
                throw;
            }
        }
    }
}
