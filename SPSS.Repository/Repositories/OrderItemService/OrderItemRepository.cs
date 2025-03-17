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

        public Task RemoveOrderItemAsync(int orderItemId)
        {
            var item = _context.OrderItems.FirstOrDefault(i => i.Id == orderItemId);
            if (item != null)
            {
                _context.OrderItems.Remove(item);
            }
            return Task.CompletedTask;
        }

        public Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            var item = _context.OrderItems.FirstOrDefault(i => i.Id == orderItemId);
            return Task.FromResult(item);
        }

        public Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            var items = _context.OrderItems.Where(i => i.OrderId == orderId).ToList();
            return Task.FromResult(items);
        }
    }
}
