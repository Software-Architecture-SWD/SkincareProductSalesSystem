using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;
using SPSS.Repository.Repositories.QuestionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.BrandRepository
{
    public class BrandRepository(AppDbContext _context) : IBrandRepository
    {
        public async Task AddAsync(Brand b)
        {
            await _context.Brands.AddAsync(b);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Brand b)
        {
            await _context.Brands.AddAsync(b);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _context.Brands.ToListAsync();
        }
        public async Task UpdateAsync(Brand b)
        {
            _context.Brands.Update(b);
            await _context.SaveChangesAsync();
        }
        public async Task<Brand?> FindByNameAsync(string brandName) 
        {
            return await _context.Brands.FirstOrDefaultAsync(b => b.BrandName == brandName);
        }
    }
}
