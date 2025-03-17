using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Repository.Enum;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.ProductService;
using System.Security.Claims;

[Route("api/[controller]")]
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
}
