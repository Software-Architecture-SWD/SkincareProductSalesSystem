using SPSS.Data;
using SPSS.Repository.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.UnitOfWork
{
    public class UnitOfWork(AppDbContext _context, IProductRepository _productRepository) : IUnitOfWork
    {
        public IProductRepository Products  {get;}


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
