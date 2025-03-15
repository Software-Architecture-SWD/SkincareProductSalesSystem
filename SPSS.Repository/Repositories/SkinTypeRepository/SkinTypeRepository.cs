using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.SkinTypeRepository
{
    public class SkinTypeRepository(AppDbContext _context) : ISkinTypeRepository
    {
        public async Task AddAsync(SkinType s)
        {
            await _context.SkinTypes.AddAsync(s);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(SkinType s)
        {
            await _context.SkinTypes.AddAsync(s);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<SkinType>> GetAllAsync()
        {
            return await _context.SkinTypes
                .Where(s => !s.isDelete)  // Chỉ lấy những bản ghi chưa bị xóa mềm
                .ToListAsync();
        }
        public async Task UpdateAsync(SkinType s)
        {
            _context.SkinTypes.Update(s);
            await _context.SaveChangesAsync();
        }
        // Cập nhật isDelete = true (Soft Delete)
        public async Task SoftDeleteAsync(int id)
        {
            var skinType = await _context.SkinTypes.FindAsync(id);
            if (skinType != null)
            {
                skinType.isDelete = true;
                await _context.SaveChangesAsync();
            }
        }
        // Cập nhật isDelete = false (Restore)
        public async Task RestoreAsync(int id)
        {
            var skinType = await _context.SkinTypes.FindAsync(id);
            if (skinType != null)
            {
                skinType.isDelete = false;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<SkinType> GetByIdAsync(int id)
        {
            return await _context.SkinTypes.FindAsync(id);
        }
        public async Task<SkinType> GetByNameAsync(string name)
        {
            return await _context.SkinTypes
                .Where(s => s.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}
