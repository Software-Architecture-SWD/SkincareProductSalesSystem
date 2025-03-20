using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;
using SPSS.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly AppDbContext _context;

        public ConversationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Conversation?> GetByIdAsync(int id)
        {
            return await _context.Conversations.FindAsync(id);
        }

        public async Task<Conversation?> GetByCustomerIdAsync(string customerId)
        {
            return await _context.Conversations
                .FirstOrDefaultAsync(c => c.UserId1 == customerId && c.UserId2 == null);
        }

        public async Task<List<Conversation>> GetWaitingConversationsAsync()
        {
            return await _context.Conversations.Where(c => c.UserId2 == null).ToListAsync();
        }

        public async Task AddAsync(Conversation conversation)
        {
            await _context.Conversations.AddAsync(conversation);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Conversation conversation)
        {
            _context.Conversations.Update(conversation);
            await _context.SaveChangesAsync();
        }
    }
}
