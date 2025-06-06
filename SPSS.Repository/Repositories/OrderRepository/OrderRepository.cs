﻿using Microsoft.EntityFrameworkCore;
using SPSS.Data;
using SPSS.Entities;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order> GetByIdAsync(int orderId)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .Include(o => o.AppUser)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
    {
        return await _context.Orders
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task UpdateOrderAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }

    public IQueryable<Category> Query()
    {
        return _context.Categories.AsQueryable();
    }

    public async Task<int> GetTotalOrderByDayAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.CompletedDate == date.Date && !o.isDelete)
            .CountAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync(DateTime? startDate, DateTime? endDate)
    {
        var orders = await _context.Orders
            .Where(o => (!startDate.HasValue || o.CreatedAt >= startDate.Value) &&
                        (!endDate.HasValue || o.CreatedAt <= endDate.Value))
            .Include(o => o.OrderItems)
            .Include(o => o.AppUser)
            .ToListAsync();
        if (orders == null)
        {
            return null;
        }
        return orders;
    }
}
