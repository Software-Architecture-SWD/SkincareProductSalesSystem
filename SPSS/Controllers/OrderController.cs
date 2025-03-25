using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.ProductService;

namespace SPSS.API.Controllers
{
    [Route("orders")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateOrder(string userId, [FromBody] CreateOrderRequest request)
        {
            try
            {
                var order = await orderService.CreateOrderAsync(userId, request.CartItemIds);
                if (order == null)
                {
                    return BadRequest(new { message = "Failed to create order." });
                }

                var orderResponse = mapper.Map<OrderResponse>(order);
                return Ok(new { message = "Order created successfully.", data = orderResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the order.", error = ex.Message });
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await orderService.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return NotFound(new { message = "Order not found." });
            }

            var orderResponse = mapper.Map<OrderResponse>(order);
            return Ok(new { message = "Order retrieved successfully.", data = orderResponse });
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotalOrdersByDay([FromQuery] DateTime date)
        {
            try
            {
                var totalOrders = await orderService.GetTotalOrdersByDayAsync(date);
                return Ok(new
                {
                    message = "Total orders retrieved successfully.",
                    data = new { date, totalOrders }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetTotalRevenue([FromQuery] DateOnly? startDate, [FromQuery] DateOnly? endDate)
        {
            try
            {
                var revenue = await orderService.GetTotalRevenue(startDate, endDate);
                return Ok(new
                {
                    message = "Revenue retrieved successfully.",
                    data = revenue
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] DateOnly? startDate, [FromQuery] DateOnly? endDate)
        {
            try
            {
                var orders = await orderService.GetOrders(startDate, endDate);
                var orderResponses = mapper.Map<IEnumerable<OrderResponse>>(orders);

                return Ok(new
                {
                    message = "Orders retrieved successfully.",
                    data = orderResponses
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
    }
}
