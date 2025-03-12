using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;
using SPSS.Repository.Repositories.QuestionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.CategoryRepository
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public async Task AddAsync(Category c)
        {
            await _context.Categories.AddAsync(c);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Category c)
        {
            await _context.Categories.AddAsync(c);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task UpdateAsync(Category c)
        {
            _context.Categories.Update(c);
            await _context.SaveChangesAsync();
        }
        public async Task<Category?> FindByNameAsync(string categoryName) 
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
        }
    }
}
