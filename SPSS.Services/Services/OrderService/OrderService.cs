using Microsoft.EntityFrameworkCore;
using SPSS.Entities;
using SPSS.Repositories;
using SPSS.Repository.Enum;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepo;
    private readonly ICartRepository _cartRepo;

    public OrderService(IOrderRepository orderRepo, ICartRepository cartRepo)
    {
        _orderRepo = orderRepo;
        _cartRepo = cartRepo;
    }

    public async Task<Order> CreateOrderFromCartAsync(string userId)
    {
        var cart = await _cartRepo.GetCartByUserIdAsync(userId);
        if (cart == null || !cart.CartItems.Any())
            throw new Exception("Cart is empty or does not exist");

        var order = new Order
        {
            UserId = userId,
            Status = OrderStatus.Pending,
            TotalAmount = cart.TotalAmount,
            ItemsCount = cart.ItemsCount,
            OrderDate = DateTime.UtcNow,
            CartId = cart.Id,
            OrderItems = cart.CartItems.Select(ci => new OrderItem
            {
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                TotalPrice = ci.TotalPrice
            }).ToList()
        };

        var createdOrder = await _orderRepo.CreateOrderAsync(order);

        // Clear the cart after order creation
        cart.CartItems.Clear();
        cart.TotalAmount = 0;
        cart.ItemsCount = 0;
        await _cartRepo.UpdateCartAsync(cart);

        return createdOrder;
    }

    public async Task<Order> GetOrderByIdAsync(int orderId)
    {
        return await _orderRepo.GetByIdAsync(orderId);
    }

    public async Task<IEnumerable<Order>> GetUserOrdersAsync(string userId)
    {
        return await _orderRepo.GetOrdersByUserIdAsync(userId);
    }

    public async Task UpdateOrderStatusAsync(int orderId, OrderStatus status)
    {
        var order = await _orderRepo.GetByIdAsync(orderId);
        if (order == null) throw new Exception("Order not found");

        order.Status = status;
        await _orderRepo.UpdateOrderAsync(order);
    }
}
