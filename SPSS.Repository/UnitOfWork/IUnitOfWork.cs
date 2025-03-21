
﻿using SPSS.Repositories;
using SPSS.Repository.Repositories.CartItemService;
using SPSS.Repository.Repositories.CategoryRepositoty;
using SPSS.Repository.Repositories.FeedbackRepository;
using SPSS.Repository.Repositories.OrderItemService;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.Repositories.PromotionRepository;
using SPSS.Repository.Repositories.AnswerRepository;
using SPSS.Repository.Repositories.QuestionRepository;
using SPSS.Repository.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPSS.Repository.Repositories.BrandReposiotry;
using SPSS.Repository.Repositories.AnswerSheetRepository;
using SPSS.Repository.Repositories.AnswerDetailRepository;
using SPSS.Repository.Repositories.PaymentRepository;
using SPSS.Repository.Repositories.ResultRepository;
using SPSS.Repository.Repositories.SkinTypeRepository;
using SPSS.Repository.Repositories;
using SPSS.Repository.Repositories.BlogCategoryReposiotry;
using SPSS.Repository.Repositories.BlogRepository;
using SPSS.Repository.Repositories.BlogContentRepository;

namespace SPSS.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IQuestionRepository Questions { get; }
        IFeedbackRepository Feedbacks { get; }
        IPromotionRepository Promotions { get; }   
        ICategoryRepository Categories { get; }
        IAnswerRepository Answers { get; }
        IAnswerDetailRepository AnswerDetails { get; }
        IBrandRepository Brands { get; }
        IAnswerSheetRepository AnswerSheets { get; }
        ICartRepository Carts { get; }
        ICartItemRepository CartItems { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        IUserRepository Users { get; }
        IPaymentRepository Payments { get; }
        IResultRepository Results { get; }
        ISkinTypeRepository SkinTypes { get; }
        IConversationRepository Conversations { get; }
        IMessageRepository Messages { get; }
        IBlogCategoryReposiotry BlogCategories { get; }
        IBlogRepository Blogs { get; }
        IBlogContentRepository BlogContents { get; }
        Task<int> CompleteAsync();
    }
}   