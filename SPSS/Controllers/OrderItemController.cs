using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Service.Dto.Response;
using SPSS.Services.Services.OrderItemService;

namespace SPSS.API.Controllers
{
    [Route("order-items")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService orderItemService;
        private readonly IMapper mapper;

        public OrderItemsController(IOrderItemService orderItemService, IMapper mapper)
        {
            this.orderItemService = orderItemService;
            this.mapper = mapper;
        }

        [HttpDelete("{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItem(int orderItemId)
        {
            try
            {
                await orderItemService.RemoveOrderItemAsync(orderItemId);
                return Ok(new { message = "Order item removed successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to remove order item.", error = ex.Message });
            }
        }

        [HttpGet("{orderItemId}")]
        public async Task<IActionResult> GetOrderItemById(int orderItemId)
        {
            try
            {
                var orderItem = await orderItemService.GetOrderItemByIdAsync(orderItemId);
                if (orderItem == null)
                {
                    return NotFound(new { message = "Order item not found." });
                }

                var orderItemResponse = mapper.Map<OrderItemResponse>(orderItem);
                return Ok(new { message = "Order item retrieved successfully.", data = orderItemResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to retrieve order item.", error = ex.Message });
            }
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetOrderItemsByOrderId(int orderId)
        {
            try
            {
                var orderItems = await orderItemService.GetOrderItemsByOrderIdAsync(orderId);
                var orderItemResponses = mapper.Map<IEnumerable<OrderItemResponse>>(orderItems);
                return Ok(new { message = "Order items retrieved successfully.", data = orderItemResponses });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to retrieve order items.", error = ex.Message });
            }
        }
    }
}
