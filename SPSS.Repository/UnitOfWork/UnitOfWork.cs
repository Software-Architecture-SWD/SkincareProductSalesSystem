using SPSS.Data;
using SPSS.Repositories;
using SPSS.Repository.Repositories.CartItemService;
using SPSS.Repository.Repositories.CategoryRepositoty;
using SPSS.Repository.Repositories.FeedbackRepository;
using SPSS.Repository.Repositories.OrderItemService;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.Repositories.PromotionRepository;
using SPSS.Repository.Repositories.QuestionRepository;
using SPSS.Repository.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.UnitOfWork
{
    public class UnitOfWork(AppDbContext _context, IProductRepository _productRepository, IQuestionRepository _questionRepository, IFeedbackRepository _feedbackRepository, IPromotionRepository _promotionRepository, ICategoryRepository _categoryRepository, ICartRepository _cartRepository, ICartItemRepository _cartItem, IOrderRepository _orderRepository, IOrderItemRepository _orderItemRepository, IUserRepository _userRepository) : IUnitOfWork
    {
        public IProductRepository Products { get; } = _productRepository;
        public IQuestionRepository Questions { get; } = _questionRepository;
        public IFeedbackRepository Feedbacks { get; } = _feedbackRepository;
        public IPromotionRepository Promotions { get; } = _promotionRepository;
        public ICategoryRepository Categories { get; } = _categoryRepository;
        public ICartRepository Carts { get; } = _cartRepository;
        public ICartItemRepository CartItems { get; } = _cartItem;
        public IOrderRepository Orders { get; } = _orderRepository;
        public IOrderItemRepository OrderItems { get; } = _orderItemRepository;
        public IUserRepository Users { get; } = _userRepository;

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
