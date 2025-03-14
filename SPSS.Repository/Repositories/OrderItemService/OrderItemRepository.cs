using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSS.Entities;
using SPSS.Repository.Entities;

namespace SPSS.Repository.Repositories.OrderItemService
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        public Task AddOrderItemAsync(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);
            return Task.CompletedTask;
        }

        public Task RemoveOrderItemAsync(int orderItemId)
        {
            var item = _orderItems.FirstOrDefault(i => i.Id == orderItemId);
            if (item != null)
            {
                _orderItems.Remove(item);
            }
            return Task.CompletedTask;
        }

        public Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            var item = _orderItems.FirstOrDefault(i => i.Id == orderItemId);
            return Task.FromResult(item);
        }

        public Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            var items = _orderItems.Where(i => i.OrderId == orderId).ToList();
            return Task.FromResult(items);
        }
    }
}
