using SPSS.Entities;

namespace SPSS.Repositories
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartByUserIdAsync(string userId);
        Task AddCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
    }
}
