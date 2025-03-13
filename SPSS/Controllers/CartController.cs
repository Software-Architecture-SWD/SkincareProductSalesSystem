using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Dto.Response;
using SPSS.Entities;
using SPSS.Service.Dto.Response;
using SPSS.Services;

[Route("api/cart")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;
    private readonly IMapper _mapper;

    public CartController(ICartService cartService, IMapper mapper)
    {
        _cartService = cartService;
        _mapper = mapper;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetCart(string userId)
    {
        var cart = await _cartService.GetCartByUserIdAsync(userId);
        if (cart == null)
        {
            cart = await _cartService.CreateCartAsync(new Cart { UserId = userId, TotalAmount = 0, ItemsCount = 0 }); 
        }
        var cartResponse = _mapper.Map<CartResponse>(cart);
        return Ok(cart);
    }

    [HttpDelete("{cartId}/clear")]
    public async Task<IActionResult> ClearCart(int cartId)
    {
        var success = await _cartService.ClearCartAsync(cartId);
        if (!success)
        {
            return NotFound("Cart not found or already empty.");
        }
        return Ok("Cart cleared successfully.");
    }
}
