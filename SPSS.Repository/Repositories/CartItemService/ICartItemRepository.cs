using System.Collections.Generic;
using System.Threading.Tasks;
using SPSS.Entities;
using SPSS.Repository.Entities;

namespace SPSS.Repository.Repositories.CartItemService
{
    public interface ICartItemRepository
    {
        Task AddCartItemAsync(CartItem cartItem);
        Task<bool> RemoveCartItemAsync(int cartItemId);
        Task<CartItem> GetCartItemByIdAsync(int cartItemId);
        Task<List<CartItem>> GetCartItemsByCartIdAsync(int cartId);
        Task UpdateCartItemAsync(CartItem cartItem, int quantity);
    }
}
