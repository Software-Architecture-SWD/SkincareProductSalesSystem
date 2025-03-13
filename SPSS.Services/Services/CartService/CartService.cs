using SPSS.Entities;
using SPSS.Repositories;

namespace SPSS.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> GetOrCreateCartAsync(string userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId, TotalAmount = 0, ItemsCount = 0 };
                await _cartRepository.AddCartAsync(cart);
            }
            return cart;
        }

        public async Task AddToCartAsync(string userId, CartItem cartItem)
        {
            var cart = await GetOrCreateCartAsync(userId);
            var existingItem = cart.CartItems.FirstOrDefault(i => i.ProductId == cartItem.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += cartItem.Quantity;
            }
            else
            {
                cart.CartItems.Add(cartItem);
            }

            cart.TotalAmount = cart.CartItems.Sum(i => i.TotalPrice * i.Quantity);
            cart.ItemsCount = cart.CartItems.Sum(i => i.Quantity);

            await _cartRepository.UpdateCartAsync(cart);
        }

        public async Task RemoveFromCartAsync(string userId, int cartItemId)
        {
            var cart = await GetOrCreateCartAsync(userId);
            var itemToRemove = cart.CartItems.FirstOrDefault(i => i.Id == cartItemId);

            if (itemToRemove != null)
            {
                cart.CartItems.Remove(itemToRemove);
                cart.TotalAmount = cart.CartItems.Sum(i => i.TotalPrice * i.Quantity);
                cart.ItemsCount = cart.CartItems.Sum(i => i.Quantity);
                await _cartRepository.UpdateCartAsync(cart);
            }
        }

        public async Task<decimal> GetTotalAmountAsync(string userId)
        {
            var cart = await GetOrCreateCartAsync(userId);
            return cart.TotalAmount;
        }
    }
}
