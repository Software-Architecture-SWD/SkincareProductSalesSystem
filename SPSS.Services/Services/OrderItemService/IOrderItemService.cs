using System.Collections.Generic;
using System.Threading.Tasks;
using SPSS.Entities;
using SPSS.Repository.Entities;

namespace SPSS.Services.Services.OrderItemService
{
    public interface IOrderItemService
    {
        Task<bool> CreateOrderItemsAsync(int orderId, IEnumerable<CartItem> cartItems);
        Task RemoveOrderItemAsync(int orderItemId);
        Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
        Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
    }
}

