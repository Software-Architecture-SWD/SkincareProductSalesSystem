using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SPSS.Repositories;
using SPSS.Repository.Repositories.CartItemService;
using SPSS.Repository.Repositories.CategoryRepositoty;
using SPSS.Repository.Repositories.FeedbackRepository;
using SPSS.Dto.Account;
using SPSS.Repository.Repositories.AnswerRepository;
using SPSS.Repository.Repositories.GenericRepository;
using SPSS.Repository.Repositories.OrderItemService;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.Repositories.PromotionRepository;
using SPSS.Repository.Repositories.QuestionRepository;
using SPSS.Repository.Repositories.User;
using SPSS.Repository.UnitOfWork;
using SPSS.Service.Services.AnswerService;
using SPSS.Service.Services.AuthService;
using SPSS.Service.Services.CartItemService;
using SPSS.Service.Services.EmailService;
using SPSS.Service.Services.FeedbackService;
using SPSS.Service.Services.FirebaseStorageService;
using SPSS.Service.Services.ProductService;
using SPSS.Service.Services.PromotionService;
using SPSS.Service.Services.QuestionService;
using SPSS.Service.Services.VNPayService;
using SPSS.Services;
using SPSS.Services.Services.CartItemService;
using SPSS.Services.Services.OrderItemService;
using VNPAY.NET;
using SPSS.Repositories;
using SPSS.Services;
using SPSS.Repository.Repositories.BrandReposiotry;
using SPSS.Service.Services.BrandService;
using SPSS.Service.Services.AnswerSheetService;
using SPSS.Repository.Repositories.AnswerSheetRepository;
using SPSS.Service.Services.AnswerDetailService;
using SPSS.Repository.Repositories.AnswerDetailRepository;
using SPSS.Repository.Repositories.PaymentRepository;
using SPSS.Repository.Repositories.ResultRepository;
using SPSS.Service.Services.ResultService;
using SPSS.Repository.Repositories.SkinTypeRepository;
using SPSS.Service.Services.SkinTypeService;
using SPSS.Service.Services.CategoryService;
using SPSS.Service.Services.CalendarService;
using SPSS.Repository.Repositories;
using SPSS.Service.Services;
using SPSS.Repository.Repositories.BlogCategoryReposiotry;
using SPSS.Service.Services.BlogCategoryService;
using SPSS.Repository.Repositories.BlogRepository;
using SPSS.Service.Services.BlogService;
using SPSS.Repository.Repositories.BlogContentRepository;
using SPSS.Service.Services.BlogContentService;
namespace SPSS
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Đăng ký các repository chung
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Đăng ký UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Đăng ký các Service
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFirebaseStorageService, FirebaseStorageService>();
            services.AddScoped<IVnpay, Vnpay>();
            services.AddScoped<IVNPayService, VNPayService>();

            // Đăng ký các Repository
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>(); 
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IAnswerSheetRepository, AnswerSheetRepository>();
            services.AddScoped<IAnswerDetailRepository, AnswerDetailRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<ISkinTypeRepository, SkinTypeRepository>();
            services.AddScoped<IBlogCategoryReposiotry, BlogCategoryReposiotry>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogContentRepository, BlogContentRepository>();

            // Đăng ký các Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IFeedbackService, FeedbackService>();           
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IAnswerSheetService, AnswerSheetService>();
            services.AddScoped<IAnswerDetailService, AnswerDetailService>();
            services.AddScoped<IResultService, ResultService>();
            services.AddScoped<ISkinTypeService, SkinTypeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICalendarService, CalendarService>();
            services.AddScoped<IBlogCategoryService, BlogCategoryService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IBlogContentService, BlogContentService>();
            //Cart
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();

            //CartItem
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICartItemService, CartItemService>();

            //Order
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            //OrderItem
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderItemService, OrderItemService>();

            //User
            services.AddScoped<IUserRepository, UserRepository>();

            //Conversation
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IChatService, ChatService>();

            return services;
        }
    }
}