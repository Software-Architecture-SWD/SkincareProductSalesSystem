using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Dto.Response;
using SPSS.Entities;
using SPSS.Service.Dto.Response;
using SPSS.Services;

namespace SPSS.API.Controllers
{
    [Route("carts")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly IMapper mapper;

        public CartsController(ICartService cartService, IMapper mapper)
        {
            this.cartService = cartService;
            this.mapper = mapper;
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetCartByUserId(string userId)
        {
            var cart = await cartService.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                cart = await cartService.CreateCartAsync(new Cart
                {
                    UserId = userId,
                    TotalAmount = 0,
                    ItemsCount = 0
                });
            }

            var cartResponse = mapper.Map<CartResponse>(cart);
            return Ok(cartResponse);
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> ClearCart(int cartId)
        {
            var success = await cartService.ClearCartAsync(cartId);
            if (!success)
            {
                return NotFound(new { message = "Cart not found or already empty." });
            }

            return Ok(new { message = "Cart cleared successfully." });
        }
    }
}
