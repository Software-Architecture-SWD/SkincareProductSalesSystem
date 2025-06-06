﻿using SPSS.Entities;
using SPSS.Repository.Enum;
using SPSS.Service.Dto.Response;

public interface IOrderService
{
    Task<OrderResponse> CreateOrderAsync(string userId, IEnumerable<int> cartItemIds);
    Task<Order> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<Order>> GetUserOrdersAsync(string userId);

    Task<int> GetTotalOrdersByDayAsync(DateTime date);

    Task<RevenueResponse> GetTotalRevenue(DateOnly? startDate, DateOnly? endDate);
    Task<IEnumerable<OrderFullResponse>> GetOrders(DateOnly? startDate, DateOnly? endDate);
}
