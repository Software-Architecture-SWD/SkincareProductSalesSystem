using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Repository.Entities;
using SPSS.Services.Services.OrderItemService;
using System.Threading.Tasks;

namespace SPSS.Controllers
{
    [Route("api/orderitem")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpDelete("remove/{orderItemId}")]
        public async Task<IActionResult> RemoveOrderItem(int orderItemId)
        {
            await _orderItemService.RemoveOrderItemAsync(orderItemId);
            return Ok(new { message = "Order item removed." });
        }

        [HttpGet("{orderItemId}")]
        public async Task<IActionResult> GetOrderItem(int orderItemId)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(orderItemId);
            return Ok(orderItem);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetOrderItems(int orderId)
        {
            var orderItems = await _orderItemService.GetOrderItemsByOrderIdAsync(orderId);
            return Ok(orderItems);
        }
    }
}
