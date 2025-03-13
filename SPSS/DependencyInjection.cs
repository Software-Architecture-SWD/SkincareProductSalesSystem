using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SPSS.Repositories;
using SPSS.Repository.Repositories.CartItemService;
using SPSS.Repository.Repositories.CategoryRepositoty;
using SPSS.Repository.Repositories.FeedbackRepository;
using SPSS.Repository.Repositories.GenericRepository;
using SPSS.Repository.Repositories.OrderItemService;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.Repositories.PromotionRepository;
using SPSS.Repository.Repositories.QuestionRepository;
using SPSS.Repository.Repositories.User;
using SPSS.Repository.UnitOfWork;
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
            services.AddScoped<ICategoryRepository, CategoryRepository>(); // Đảm bảo CategoryRepository đã được đăng ký

            // Đăng ký các Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            
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

            return services;
        }
    }
}