using SPSS.Entities;

namespace SPSS.Services.Services.CartItemService
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId);
        Task<CartItem> AddToCartAsync(int cartId, int productId);
        Task<bool> RemoveCartItemAsync(int cartItemId);
        Task<CartItem> UpdateCartItemAsync(int cartItemId, int quantity);
    }
}

