using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;

namespace SPSS.Repository.Repositories.QuestionRepository
{
    public class QuestionRepository(AppDbContext _context) : IQuestionRepository
    {
        public async Task AddAsync(Question q)
        {
            await _context.Question.AddAsync(q);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Question q)
        {
            await _context.Question.AddAsync(q);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Question.Include(q => q.Answers).ToListAsync();
        }
        public async Task UpdateAsync(Question q)
        {
            _context.Question.Update(q);
            await _context.SaveChangesAsync();
        }
    }
    
}
