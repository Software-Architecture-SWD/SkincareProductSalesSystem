using SPSS.Entities;
using SPSS.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories
{
    public interface IConversationRepository
    {
        Task<Conversation?> GetByIdAsync(int id);
        Task<Conversation?> GetByCustomerIdAsync(string customerId);
        Task<List<Conversation>> GetWaitingConversationsAsync();
        Task AddAsync(Conversation conversation);
        Task UpdateAsync(Conversation conversation);
    }
}
