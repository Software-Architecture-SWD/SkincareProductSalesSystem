using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Response;
using SPSS.Services.Services.CartItemService;

[Route("api/cart-items")]
[ApiController]
public class CartItemController : ControllerBase
{
    private readonly ICartItemService _cartItemService;
    private readonly IMapper _mapper;

    public CartItemController(ICartItemService cartItemService, IMapper mapper)
    {
        _cartItemService = cartItemService;
        _mapper = mapper;
    }

    [HttpGet("{cartId}")]
    public async Task<IActionResult> GetCartItems(int cartId)
    {
        var cartItems = await _cartItemService.GetCartItemsByCartIdAsync(cartId);
        var cartItemsResponse = _mapper.Map<List<CartItemResponse>>(cartItems);
        return Ok(cartItemsResponse);
    }

    [HttpPost("{cartId}")]
    public async Task<IActionResult> AddToCart(int cartId, int productId)
    {
        var cartItem = await _cartItemService.AddToCartAsync(cartId, productId);
        var cartItemResponse = _mapper.Map<CartItemResponse>(cartItem);
        return Ok(cartItemResponse);
    }

    [HttpPut("{cartItemId}")]
    public async Task<IActionResult> UpdateCartItem(int cartItemId, int quantity)
    {
        var cartItem = await _cartItemService.UpdateCartItemAsync(cartItemId, quantity);
        var cartItemResponse = _mapper.Map<CartItemResponse>(cartItem);
        return Ok(cartItemResponse);
    }

    [HttpDelete("{cartItemId}")]
    public async Task<IActionResult> RemoveFromCart(int cartItemId)
    {
        await _cartItemService.RemoveCartItemAsync(cartItemId);
        return Ok("Cart item removed");
    }
}
