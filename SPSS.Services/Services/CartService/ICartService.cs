using SPSS.Entities;

namespace SPSS.Services
{
    public interface ICartService
    {
        Task<Cart> GetOrCreateCartAsync(string userId);
        Task AddToCartAsync(string userId, CartItem cartItem);
        Task RemoveFromCartAsync(string userId, int cartItemId);
        Task<decimal> GetTotalAmountAsync(string userId);
    }
}
