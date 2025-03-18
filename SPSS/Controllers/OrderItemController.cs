using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Repository.Entities;
using SPSS.Service.Dto.Response;
using SPSS.Services.Services.OrderItemService;
using System.Threading.Tasks;

namespace SPSS.Controllers
{
    [Route("api/orderitem")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _mapper = mapper;
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
            var orderItemsResponse = _mapper.Map<IEnumerable<OrderItemResponse>>(orderItems);
            return Ok(orderItemsResponse);
        }
    }
}
