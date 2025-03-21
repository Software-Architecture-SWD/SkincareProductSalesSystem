using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repositories;
using SPSS.Repository.Enum;
using SPSS.Repository.UnitOfWork;
using SPSS.Service.Dto.Response;
using SPSS.Services.Services.CartItemService;
using SPSS.Services.Services.OrderItemService;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<OrderService> _logger;
    private readonly IOrderItemService _orderItemService;
    private readonly ICartItemService _cartItemService;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, ILogger<OrderService> logger, IOrderItemService orderItemService, ICartItemService cartItemService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _orderItemService = orderItemService;
        _cartItemService = cartItemService;
        _mapper = mapper;
    }

    public async Task<OrderResponse> CreateOrderAsync(string userId, IEnumerable<int> cartItemIds)
    {
        var user = await _unitOfWork.Users.GetUserById(userId);
        if (user == null)
        {
            _logger.LogWarning("User with ID {Id} does not exist", userId);
            throw new InvalidOperationException($"User with ID {userId} does not exist.");
        }

        var cart = await _unitOfWork.Carts.GetCartByUserIdAsync(userId);
        if (cart == null || !cart.CartItems.Any())
        {
            _logger.LogWarning("Cart is empty or does not exist.");
            throw new InvalidOperationException("Cart is empty or does not exist.");
        }

        var selectedCartItems = cart.CartItems
            .Where(ci => cartItemIds.Contains(ci.Id))
            .ToList();
        if (!selectedCartItems.Any())
        {
            _logger.LogWarning("No valid cart items selected.");
            throw new InvalidOperationException("No valid cart items selected.");
        }

        var order = new Order
        {
            UserId = userId,
            Status = OrderStatus.Pending,
            isDelete = false,
        };

        var createdOrder = _mapper.Map <OrderResponse> (await _unitOfWork.Orders.CreateOrderAsync(order));

        // Call OrderItemService to create OrderItems separately
        var orderItems = await _orderItemService.CreateOrderItemsAsync(createdOrder.Id, selectedCartItems);

        createdOrder.OriginalTotalAmount = createdOrder.TotalAmount;

        // Delete only selected cart items after order is successfully created
        var cartItemCheck = await _cartItemService.RemoveCartItemsAsync(cartItemIds);

        return createdOrder;
    }



    public async Task<Order> GetOrderByIdAsync(int orderId)
    {
        return await _unitOfWork.Orders.GetByIdAsync(orderId);
    }

    public async Task<IEnumerable<Order>> GetUserOrdersAsync(string userId)
    {
        return await _unitOfWork.Orders.GetOrdersByUserIdAsync(userId);
    }

    public async Task<int> GetTotalOrdersByDayAsync(DateTime date)
    {
        try
        {
            _logger.LogInformation("Fetching total orders for date: {Date}", date);
            var count = await _unitOfWork.Orders.GetTotalOrderByDayAsync(date);
            _logger.LogInformation("Total orders for {Date}: {Count}", date, count);
            return count;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving order count for date: {Date}", date);
            throw new Exception("Error retrieving order count", ex);
        }
    }
}
