using SPSS.Entities;

namespace SPSS.Services
{
    public interface ICartService
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task<Cart> CreateCartAsync(Cart cart);
        Task<bool> ClearCartAsync(int cartId);
    }
}
