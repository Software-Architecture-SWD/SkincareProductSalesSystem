using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Repository.Enum;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
[Authorize] // Requires authentication
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    //[HttpPost("create/{userId}")]
    //public async Task<IActionResult> CreateOrder(string userId)
    //{
    //    try
    //    {
    //        var order = await _orderService.CreateOrderAsync(new Order { UserId = userId, Status = OrderStatus.Pending });
    //        return Ok(order);
    //    }
    //    catch (Exception ex)
    //    {   
    //        return BadRequest(new { message = ex.Message });
    //    }
    //}

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById(int orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        if (order == null) return NotFound();

        return Ok(order);
    }

    [HttpGet("user-orders")]
    public async Task<IActionResult> GetUserOrders()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized();

        var orders = await _orderService.GetUserOrdersAsync(userId);
        return Ok(orders);
    }

    [HttpPut("{orderId}/status")]
    public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] OrderStatus status)
    {
        try
        {
            await _orderService.UpdateOrderStatusAsync(orderId, status);
            return Ok(new { message = "Order status updated" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
