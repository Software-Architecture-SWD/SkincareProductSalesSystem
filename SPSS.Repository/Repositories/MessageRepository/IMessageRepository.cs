using SPSS.Entities;
using SPSS.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories
{
    public interface IMessageRepository
    {
        Task AddAsync(Message message);
        Task<List<Message>> GetMessagesByConversationIdAsync(int conversationId);
        Task<Message?> GetByIdAsync(int messageId);
        Task UpdateAsync(Message message);
    }
}
