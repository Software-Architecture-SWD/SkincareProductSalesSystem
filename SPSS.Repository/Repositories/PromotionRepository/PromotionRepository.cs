using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;
using SPSS.Repository.Repositories.QuestionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.PromotionRepository
{
    public class PromotionRepository(AppDbContext _context) : IPromotionRepository
    {
        public async Task AddAsync(Promotion p)
        {
            await _context.Promotions.AddAsync(p);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Promotion p)
        {
            await _context.Promotions.AddAsync(p);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Promotion>> GetAllAsync()
        {
            return await _context.Promotions.ToListAsync();
        }
        public async Task UpdateAsync(Promotion p)
        {
            _context.Promotions.Update(p);
            await _context.SaveChangesAsync();
        }
        public async Task<Promotion> GetByIdAsync(int id)
        {
            return await _context.Promotions
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public IQueryable<Promotion> Query()
        {
            return _context.Promotions.AsQueryable(); 
        }
    }
}

