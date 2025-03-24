using SPSS.Entities;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int orderId);
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
    Task<Order> CreateOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int orderId);
    IQueryable<Category> Query();
    Task<int> GetTotalOrderByDayAsync(DateTime date);
    Task<IEnumerable<Order>> GetOrdersAsync(DateTime? startDate, DateTime? endDate);
}
    