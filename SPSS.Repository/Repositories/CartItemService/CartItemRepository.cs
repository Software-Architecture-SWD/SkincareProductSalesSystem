using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;
using SPSS.Repository.Entities;

namespace SPSS.Repository.Repositories.CartItemService
{
    public class CartItemRepository(AppDbContext _context) : ICartItemRepository
    {
        public async Task AddCartItemAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
        }

        public async Task<bool> RemoveCartItemAsync(int cartItemId)
        {
            var item = await _context.CartItems.FirstOrDefaultAsync(i => i.Id == cartItemId);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        {
            var item = _context.CartItems.Where(i => i.Id == cartItemId).Include(i => i.Product).FirstOrDefault();
            return item;
        }

        public async Task<List<CartItem>> GetCartItemsByCartIdAsync(int cartId)
        {
            var items = _context.CartItems.Where(i => i.CartId == cartId).Include(i=> i.Product).ToList();
            return items;
        }

        public async Task UpdateCartItemAsync(CartItem cartItem, int quantity)
        {
            cartItem.Quantity = quantity;
            _context.Update(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<CartItem> cartItems)
        {
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByIdAsync(IEnumerable<int> cartItemIds)
        {
            if (cartItemIds == null || !cartItemIds.Any()) return Enumerable.Empty<CartItem>();

            return await _context.CartItems
                .Where(i => cartItemIds.Contains(i.Id))
                .Include(i => i.Product)
                .ToListAsync();
        }

    }
}
