using Microsoft.Extensions.DependencyInjection;
using SPSS.Repository.Repositories.CategoryRepositoty;
using SPSS.Repository.Repositories.FeedbackRepository;
using SPSS.Dto.Account;
using SPSS.Repository.Repositories.AnswerRepository;
using SPSS.Repository.Repositories.GenericRepository;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.Repositories.PromotionRepository;
using SPSS.Repository.Repositories.QuestionRepository;
using SPSS.Repository.UnitOfWork;
using SPSS.Service.Services.AnswerService;
using SPSS.Service.Services.AuthService;
using SPSS.Service.Services.EmailService;
using SPSS.Service.Services.FeedbackService;
using SPSS.Service.Services.FirebaseStorageService;
using SPSS.Service.Services.ProductService;
using SPSS.Service.Services.PromotionService;
using SPSS.Service.Services.QuestionService;
using SPSS.Service.Services.VNPayService;
using VNPAY.NET;
using SPSS.Repositories;
using SPSS.Services;
using SPSS.Repository.Repositories.BrandReposiotry;
using SPSS.Service.Services.BrandService;
using SPSS.Service.Services.AnswerSheetService;
using SPSS.Repository.Repositories.AnswerSheetRepository;
using SPSS.Service.Services.AnswerDetailService;
using SPSS.Repository.Repositories.AnswerDetailRepository;
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

            // Đăng ký các Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IFeedbackService, FeedbackService>();             
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IAnswerSheetService, AnswerSheetService>();
            services.AddScoped<IAnswerDetailService, AnswerDetailService>();

            return services;
        }
    }
}