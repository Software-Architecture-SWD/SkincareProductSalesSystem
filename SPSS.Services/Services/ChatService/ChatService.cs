using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<ChatService> _logger;

        public ChatService(IConversationRepository conversationRepo, IMessageRepository messageRepo, UserManager<AppUser> userManager, ILogger<ChatService> logger)
        {
            _conversationRepo = conversationRepo;
            _messageRepo = messageRepo;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<Response> StartConversationAsync(StartChatRequest request)
        {
            try
            {
                _logger.LogInformation("Customer {CustomerId} started a conversation.", request.CustomerId);

                var customer = await _userManager.FindByIdAsync(request.CustomerId);
                if (customer == null)
                {
                    _logger.LogWarning("Customer ID {CustomerId} does not exist.", request.CustomerId);
                    return new Response { Success = false, Message = "Customer does not exist." };
                }

                var conversation = await _conversationRepo.GetByCustomerIdAsync(request.CustomerId);

                if (conversation == null)
                {
                    conversation = new Conversation
                    {
                        UserId1 = request.CustomerId,
                        UserId2 = null, // No expert assigned yet
                        CreatedAt = DateTime.UtcNow
                    };

                    await _conversationRepo.AddAsync(conversation);
                    _logger.LogInformation("New conversation created with ID {ConversationId}.", conversation.Id);
                }

                conversation = await _conversationRepo.GetByCustomerIdAsync(request.CustomerId);
                if (conversation == null || conversation.Id == 0)
                {
                    _logger.LogWarning("Failed to create a conversation for Customer {CustomerId}.", request.CustomerId);
                    return new Response { Success = false, Message = "Failed to create a conversation." };
                }

                var message = new Message
                {
                    ConversationId = conversation.Id,
                    SenderId = request.CustomerId,
                    Content = request.Message,
                    CreatedAt = DateTime.UtcNow
                };

                await _messageRepo.AddAsync(message);

                var expert = conversation.UserId2 != null ? await _userManager.FindByIdAsync(conversation.UserId2) : null;
                string customerName = customer.UserName ?? "Customer";
                string expertName = expert?.UserName ?? "No Expert Assigned";

                _logger.LogInformation("Message sent in conversation ID {ConversationId}.", conversation.Id);

                return new Response
                {
                    Success = true,
                    Message = "Conversation has been created.",
                    Data = new
                    {
                        ConversationId = conversation.Id,
                        CustomerId = request.CustomerId,
                        CustomerName = customerName,
                        ExpertId = conversation.UserId2,
                        ExpertName = expertName
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a conversation for Customer {CustomerId}.", request.CustomerId);
                return new Response { Success = false, Message = "An unexpected error occurred." };
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
                _logger.LogError(ex, "Error while retrieving waiting conversations.");
                throw;
            }
        }


        // ✅ 3. Expert nhận cuộc trò chuyện
        public async Task<Response> AcceptConversationAsync(int conversationId, AcceptChatRequest request)
        {
            try
            {
                _logger.LogInformation("Expert {ExpertId} accepted conversation ID {ConversationId}", request.ExpertId, conversationId);

                var conversation = await _conversationRepo.GetByIdAsync(conversationId);
                if (conversation == null || conversation.UserId2 != null)
                {
                    _logger.LogWarning("Conversation ID {ConversationId} has already been accepted or does not exist.", conversationId);
                    return new Response { Success = false, Message = "The conversation has already been accepted." };
                }

                conversation.UserId2 = request.ExpertId;
                await _conversationRepo.UpdateAsync(conversation);
                _logger.LogInformation("Expert {ExpertId} successfully accepted conversation ID {ConversationId}.", request.ExpertId, conversationId);

                return new Response { Success = true, Message = "Expert has accepted the conversation." };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while Expert {ExpertId} accepting conversation ID {ConversationId}.", request.ExpertId, conversationId);
                throw;
            }
        }


        // ✅ 4. Gửi tin nhắn
        public async Task<Response> SendMessageAsync(SendMessageRequest request)
        {
            try
            {
                _logger.LogInformation("User {SenderId} sent a message in conversation ID {ConversationId}.", request.SenderId, request.ConversationId);

                var sender = await _userManager.FindByIdAsync(request.SenderId);
                if (sender == null)
                {
                    _logger.LogWarning("Sender ID {SenderId} does not exist.", request.SenderId);
                    return new Response { Success = false, Message = "Sender does not exist." };
                }

                var message = new Message
                {
                    ConversationId = request.ConversationId,
                    SenderId = request.SenderId,
                    Content = request.Message,
                    CreatedAt = DateTime.UtcNow
                };
                await _messageRepo.AddAsync(message);

                _logger.LogInformation("Message successfully sent.");
                return new Response
                {
                    Success = true,
                    Message = "Message has been sent.",
                    Data = new
                    {
                        MessageId = message.Id,
                        SenderId = message.SenderId,
                        SenderName = sender.FullName,
                        Content = message.Content,
                        CreatedAt = message.CreatedAt
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while sending a message in conversation ID {ConversationId}.", request.ConversationId);
                return new Response { Success = false, Message = "Failed to send message." };
            }
        }


        // ✅ 5. Lấy lịch sử tin nhắn
        public async Task<List<MessageResponse>> GetChatHistoryAsync(int conversationId)
        {
            try
            {
                _logger.LogInformation("Fetching chat history for conversation ID {ConversationId}.", conversationId);

                var messages = await _messageRepo.GetMessagesByConversationIdAsync(conversationId);
                var userIds = messages.Select(m => m.SenderId).Distinct().ToList();
                var users = await _userManager.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();

                var response = messages.Select(m => new MessageResponse
                {
                    Id = m.Id,
                    SenderId = m.SenderId,
                    SenderName = users.FirstOrDefault(u => u.Id == m.SenderId)?.FullName ?? "Unknown",
                    Content = m.Content,
                    CreatedAt = m.CreatedAt
                }).ToList();

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving chat history for conversation ID {ConversationId}.", conversationId);
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
