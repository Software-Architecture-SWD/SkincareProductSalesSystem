using Microsoft.EntityFrameworkCore;
using SPSS.Entities;
using SPSS.Repositories;
using SPSS.Repository.UnitOfWork;

namespace SPSS.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ClearCartAsync(int cartId)
        {
            var cartItems = await _unitOfWork.CartItems.GetCartItemsByCartIdAsync(cartId);

            if (!cartItems.Any()) return false;

            foreach (var item in cartItems)
            {
                await _unitOfWork.CartItems.RemoveCartItemAsync(item.Id);
            }
            var saved = await _unitOfWork.CompleteAsync();
            if (saved == 0) return false;
            return true;
        }

        public async Task<Cart> CreateCartAsync(Cart cart)
        {
            var newCart = await _unitOfWork.Carts.AddCartAsync(cart);
            await _unitOfWork.CompleteAsync(); // Ensure changes are saved
            return newCart;
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            var user = await _unitOfWork.Users.GetUserById(userId);
            var cart = await _unitOfWork.Carts.GetCartByUserIdAsync(userId);
            return cart;
        }
    }
}
