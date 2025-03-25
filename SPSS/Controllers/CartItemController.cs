using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Response;
using SPSS.Services.Services.CartItemService;

namespace SPSS.API.Controllers
{
    [Route("cart-items")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService cartItemService;
        private readonly IMapper mapper;

        public CartItemsController(ICartItemService cartItemService, IMapper mapper)
        {
            this.cartItemService = cartItemService;
            this.mapper = mapper;
        }

        [HttpGet("{cartItemId}")]
        public async Task<IActionResult> GetCartItemById(int cartItemId)
        {
            var cartItem = await cartItemService.GetCartItemByIdAsync(cartItemId);
            if (cartItem == null)
            {
                return NotFound(new { message = "Cart item not found." });
            }

            var cartItemResponse = mapper.Map<CartItemResponse>(cartItem);
            return Ok(cartItemResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItemsByCartId([FromQuery] int cartId)
        {
            var cartItems = await cartItemService.GetCartItemsByCartIdAsync(cartId);
            var cartItemsResponse = mapper.Map<IEnumerable<CartItemResponse>>(cartItems);
            return Ok(cartItemsResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromQuery] int cartId, [FromQuery] int productId)
        {
            var cartItem = await cartItemService.AddToCartAsync(cartId, productId);
            var cartItemResponse = mapper.Map<CartItemResponse>(cartItem);
            return Ok(cartItemResponse);
        }

        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> UpdateCartItemQuantity(int cartItemId, [FromQuery] int quantity)
        {
            var cartItem = await cartItemService.UpdateCartItemAsync(cartItemId, quantity);
            var cartItemResponse = mapper.Map<CartItemResponse>(cartItem);
            return Ok(cartItemResponse);
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> DeleteCartItem(int cartItemId)
        {
            await cartItemService.RemoveCartItemAsync(cartItemId);
            return Ok(new { message = "Cart item removed successfully." });
        }
    }
}
