using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.ResultRepository
{
    public class ResultRepository(AppDbContext _context) : IResultRepository
    {
        public async Task<IEnumerable<Result>> GetAllAsync()
        {
            return await _context.Results
                .Include(r => r.SkinType)
                .ToListAsync();
        }
        public async Task AddAsync(Result result)
        {
            await _context.Results.AddAsync(result);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Result result)
        {
            _context.Results.Update(result);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Result result)
        {
            _context.Results.Remove(result);
            await _context.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            var result = await _context.Results.FindAsync(id);
            if (result != null)
            {
                result.isDelete = true;
                await _context.SaveChangesAsync();
            }
        }
        public async Task RestoreAsync(int id)
        {
            var result = await _context.Results.FindAsync(id);
            if (result != null)
            {
                result.isDelete = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}

