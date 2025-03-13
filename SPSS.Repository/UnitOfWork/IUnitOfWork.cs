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
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IQuestionRepository Questions { get; }
        IFeedbackRepository Feedbacks { get; }
        IPromotionRepository Promotions { get; }   
        ICategoryRepository Categories { get; }
        ICartRepository Carts { get; }
        ICartItemRepository CartItems { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        IUserRepository Users { get; }

        Task<int> CompleteAsync();
    }
}   