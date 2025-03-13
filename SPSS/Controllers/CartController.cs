using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Services;

namespace SPSS.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(string userId)
        {
            var cart = await _cartService.GetOrCreateCartAsync(userId);
            return Ok(cart);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartItem cartItem, [FromQuery] string userId)
        {
            await _cartService.AddToCartAsync(userId, cartItem);
            return Ok(new { message = "Item added to cart." });
        }

        [HttpDelete("remove/{userId}/{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(string userId, int cartItemId)
        {
            await _cartService.RemoveFromCartAsync(userId, cartItemId);
            return Ok(new { message = "Item removed from cart." });
        }

        [HttpGet("total/{userId}")]
        public async Task<IActionResult> GetTotalAmount(string userId)
        {
            var total = await _cartService.GetTotalAmountAsync(userId);
            return Ok(new { total });
        }
    }
}
