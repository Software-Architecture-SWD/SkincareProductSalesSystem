using System.Collections.Generic;
using System.Threading.Tasks;
using SPSS.Entities;
using SPSS.Repository.Entities;

namespace SPSS.Repository.Repositories.OrderItemService
{
    public interface IOrderItemRepository
    {
        Task AddOrderItemsAsync(IEnumerable<OrderItem> orderItems);
        Task RemoveOrderItemAsync(int orderItemId);
        Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
        Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
        Task<List<OrderItem>> GetOrderItems();
    }
}
