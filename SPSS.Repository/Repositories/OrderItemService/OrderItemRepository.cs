using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;
using SPSS.Repository.Entities;

namespace SPSS.Repository.Repositories.OrderItemService
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _context;

        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddOrderItemsAsync(IEnumerable<OrderItem> orderItems)
        {
            _context.AddRange(orderItems);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveOrderItemAsync(int orderItemId)
        {
            var item = _context.OrderItems.FirstOrDefault(i => i.Id == orderItemId);
            if (item != null)
            {
                _context.OrderItems.Remove(item);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return await _context.OrderItems
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == orderItemId);
        }

        public async Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await _context.OrderItems
                .Where(i => i.OrderId == orderId)
                .Include(i => i.Product)
                .ToListAsync();
        }

        public async Task<List<OrderItem>> GetOrderItems()
        {
            return await _context.OrderItems.Include(i => i.Product).ToListAsync();

        }
    }
}
