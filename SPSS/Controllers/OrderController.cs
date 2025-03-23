using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Repository.Enum;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.ProductService;
using System.Security.Claims;

[Route("orders")]
[ApiController]
[Authorize] // Requires authentication
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> CreateOrder(string userId, [FromBody] CreateOrderRequest request)
    {
        try
        {
            var order = await _orderService.CreateOrderAsync(userId, request.CartItemIds);
            if (order == null) return BadRequest(new { message = "Failed to create order." });
            return Ok(order);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById(int orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        if (order == null) return NotFound();
        var orderResponse = _mapper.Map<OrderResponse>(order);
        return Ok(orderResponse);
    }


    [HttpGet("total")]
    public async Task<IActionResult> GetTotalOrdersByDay([FromQuery] DateTime date)
    {
        try
        {
            var result = await _orderService.GetTotalOrdersByDayAsync(date);
            return Ok(new { Date = date, TotalOrders = result });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Internal Server Error", Details = ex.Message });
        }
    }
}
