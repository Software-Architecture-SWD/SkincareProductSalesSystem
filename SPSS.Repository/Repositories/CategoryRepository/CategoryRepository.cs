using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;
using SPSS.Repository.Repositories.QuestionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.CategoryRepositoty
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category); 
            await _context.SaveChangesAsync();  
        }

 
        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);  
            await _context.SaveChangesAsync();  
        }

    
        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            category.isDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public IQueryable<Category> Query()
        {
            return _context.Categories.AsQueryable();
        }
    }

}
