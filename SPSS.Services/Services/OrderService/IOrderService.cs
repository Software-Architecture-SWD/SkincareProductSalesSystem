using SPSS.Entities;
using SPSS.Repository.Enum;

public interface IOrderService
{
    Task<Order> CreateOrderFromCartAsync(string userId);
    Task<Order> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<Order>> GetUserOrdersAsync(string userId);
    Task UpdateOrderStatusAsync(int orderId, OrderStatus status);
}
