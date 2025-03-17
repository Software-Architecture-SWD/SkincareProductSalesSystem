using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;

namespace SPSS.Repositories
{
    public class CartRepository(AppDbContext _context) : ICartRepository
    {
        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await _context.Carts.Where(c => c.UserId == userId).Include(c => c.CartItems).FirstOrDefaultAsync();
        }

        public async Task<Cart> AddCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            _context.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCartById(int id)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
