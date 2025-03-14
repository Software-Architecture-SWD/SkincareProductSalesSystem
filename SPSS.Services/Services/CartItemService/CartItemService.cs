using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using SPSS.Services.Services.CartItemService;

namespace SPSS.Service.Services.CartItemService
{
    public class CartItemService : ICartItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CartItemService> _logger;

        public CartItemService(IUnitOfWork unitOfWork, ILogger<CartItemService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CartItem> AddToCartAsync(int cartId, int productId)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);

            if (product == null)
            {
                _logger.LogWarning("Product with ID {Id} not found.", productId);
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            if (product.StockQuantity <= 0)
            {
                _logger.LogWarning("Product with ID {Id} is out of stock.", productId);
                throw new InvalidOperationException($"Product with ID {productId} is out of stock.");
            }

            var cart = await _unitOfWork.Carts.GetCartById(cartId);
            if (cart == null)
            {
                _logger.LogWarning("Cart with ID {Id} not found.", cartId);
                throw new KeyNotFoundException($"Cart with ID {cartId} not found.");
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += 1;
                await _unitOfWork.CartItems.UpdateCartItemAsync(cartItem, cartItem.Quantity);
            }
            else
            {
                cartItem = new CartItem
                {
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = 1,
                };

                await _unitOfWork.CartItems.AddCartItemAsync(cartItem);
            }

            await _unitOfWork.CompleteAsync();

            return cartItem;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId)
        {
            var cart = await _unitOfWork.Carts.GetCartById(cartId);
            if (cart == null)
            {
                _logger.LogWarning("Cart with ID {Id} not found.", cartId);
                throw new KeyNotFoundException($"Cart with ID {cartId} not found.");
            }

            var cartItems = await _unitOfWork.CartItems.GetCartItemsByCartIdAsync(cartId);
            return cartItems;
        }

        public async Task<bool> RemoveCartItemAsync(int cartItemId)
        {
            var cartItem = _unitOfWork.CartItems.GetCartItemByIdAsync(cartItemId);
            if (cartItem == null)
            {
                _logger.LogWarning("Cart item with ID {Id} not found.", cartItemId);
                throw new KeyNotFoundException($"Cart item with ID {cartItemId} not found.");
            }
            return await _unitOfWork.CartItems.RemoveCartItemAsync(cartItemId);
        }

        public async Task<CartItem> UpdateCartItemAsync(int cartItemId, int quantity)
        {
            var cartItem = await _unitOfWork.CartItems.GetCartItemByIdAsync(cartItemId);
            if (cartItem == null)
            {
                _logger.LogWarning("Cart item with ID {Id} not found.", cartItemId);
                throw new KeyNotFoundException($"Cart item with ID {cartItemId} not found.");
            }

            var product = await _unitOfWork.Products.GetByIdAsync(cartItem.ProductId);
            if (product == null)
            {
                _logger.LogWarning("The product with the ID {Id} is not found", product.Id);
                throw new KeyNotFoundException($"product with ID {product.Id} not found.");
            }

            if (cartItem.Product.StockQuantity < 0)
            {
                _logger.LogWarning("Product with ID {Id} is out of stock.", cartItem.ProductId);
                throw new InvalidOperationException($"Product with ID {cartItem.ProductId} is out of stock.");
            }
            if (cartItem.Product.StockQuantity < quantity)
            {
                _logger.LogWarning("Product with ID {Id} has insufficient stock.", cartItem.ProductId);
                throw new InvalidOperationException($"Product with ID {cartItem.ProductId} has insufficient stock.");
            }
            cartItem.Product.StockQuantity -= quantity;
            cartItem.Quantity = quantity;
            cartItem.TotalPrice = cartItem.Product.Price * quantity;
            await _unitOfWork.CartItems.UpdateCartItemAsync(cartItem, quantity);
            return cartItem;
        }
    }
}
