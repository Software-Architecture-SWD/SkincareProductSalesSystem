using SPSS.Entities;

public interface IOrderService
{
    Task<Order> CreateOrderFromCartAsync(string userId);
    Task<Order> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<Order>> GetUserOrdersAsync(string userId);
    Task UpdateOrderStatusAsync(int orderId, string status);
}
