using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Blog b)
        {
            await _context.Blogs.AddAsync(b);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _context.Blogs
                .Where(b => !b.isDelete)
                .Include(b => b.Contents)
                .ToListAsync();
        }

        public async Task UpdateAsync(Blog b)
        {
            _context.Blogs.Update(b);
            await _context.SaveChangesAsync();
        }

        // Cập nhật isDelete = true (Soft Delete)
        public async Task SoftDeleteAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                blog.isDelete = true;
                await _context.SaveChangesAsync();
            }
        }

        // Cập nhật isDelete = false (Restore)
        public async Task RestoreAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                blog.isDelete = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _context.Blogs
                .Where(b => b.Id == id)
                .Where(b => !b.isDelete)
                .Include(b => b.Contents)
                .FirstOrDefaultAsync();
        }
    }
}
