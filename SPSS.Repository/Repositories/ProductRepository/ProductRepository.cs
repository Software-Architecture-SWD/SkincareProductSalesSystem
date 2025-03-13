using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SPSS.Data;
using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.ProductRepository
{
    public class ProductRepository(AppDbContext _context) : IProductRepository
    {
        public async Task AddAsync(Product p)
        {
            await _context.Products.AddAsync(p);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            product.isDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product p)
        {
            _context.Products.Update(p);
            await _context.SaveChangesAsync();
        }

        public async Task<Brand> GetBrandByNameAsync(string brandName)
        {
            return await _context.Brands.FirstOrDefaultAsync(b => b.BrandName == brandName);
        }

        public async Task<Category> GetCategoryByNameAsync(string categoryName)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);

        }

        public IQueryable<Product> Query()
        {
            return _context.Products.AsQueryable();
        }
    }
}
