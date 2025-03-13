using SPSS.Entities;

namespace SPSS.Repositories
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartByUserIdAsync(string userId);
        Task<Cart> AddCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
        Task<Cart> GetCartById(int id);
    }
}
