using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Repository.Entities;

namespace SPSS.Repository.Repositories.BlogContentRepository
{
    public class BlogContentRepository(AppDbContext _context) : IBlogContentRepository
    {
        public async Task AddAsync(BlogContent b)
        {
            await _context.BlogContents.AddAsync(b);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var blogContent = await _context.BlogContents.FindAsync(id);
            if (blogContent != null)
            {
                _context.BlogContents.Remove(blogContent);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<BlogContent>> GetAllAsync()
        {
            return await _context.BlogContents
                .ToListAsync();
        }
        public async Task UpdateAsync(BlogContent b)
        {
            _context.BlogContents.Update(b);
            await _context.SaveChangesAsync();
        }

    }
}
