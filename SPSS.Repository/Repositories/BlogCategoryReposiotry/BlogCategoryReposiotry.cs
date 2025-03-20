using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.BlogCategoryReposiotry
{
    public class BlogCategoryReposiotry(AppDbContext _context) : IBlogCategoryReposiotry
    {
        public async Task AddAsync(BlogCategory a)
        {
            await _context.BlogCategories.AddAsync(a);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(BlogCategory a)
        {
            await _context.BlogCategories.AddAsync(a);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<BlogCategory>> GetAllAsync()
        {
            return await _context.BlogCategories
                .Where(a => !a.isDelete)
                .ToListAsync();
        }
        public async Task UpdateAsync(BlogCategory a)
        {
            _context.BlogCategories.Update(a);
            await _context.SaveChangesAsync();
        }
        public async Task<BlogCategory> GetByIdAsync(int id)
        {
            return await _context.BlogCategories
                .Where(a => a.Id == id)
                .Where(a => !a.isDelete)
                .FirstOrDefaultAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            var blogCategory = await _context.BlogCategories.FindAsync(id);
            if (blogCategory != null)
            {
                blogCategory.isDelete = true;
                await _context.SaveChangesAsync();
            }
        }
        public async Task RestoreAsync(int id)
        {
            var blogCategory = await _context.BlogCategories.FindAsync(id);
            if (blogCategory != null)
            {
                blogCategory.isDelete = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
