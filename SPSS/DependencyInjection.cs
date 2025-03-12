using Microsoft.Extensions.DependencyInjection;
using SPSS.Dto.Account;
using SPSS.Repositories;
using SPSS.Repository.Repositories.GenericRepository;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.Repositories.QuestionRepository;
using SPSS.Repository.UnitOfWork;
using SPSS.Service.Services.AuthService;
using SPSS.Service.Services.EmailService;
using SPSS.Service.Services.FirebaseStorageService;
using SPSS.Service.Services.ProductService;
using SPSS.Service.Services.QuestionService;
using SPSS.Service.Services.VNPayService;
using SPSS.Services;
using System.Collections.Concurrent;
using VNPAY.NET;

namespace SPSS
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //FireBase
            services.AddScoped<IFirebaseStorageService, FirebaseStorageService>();

            // UIT
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Auth
            services.AddScoped<IAuthService, AuthService>();

            // Product
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //VNPay
            services.AddScoped<IVnpay, Vnpay>();
            services.AddScoped<IVNPayService, VNPayService>();

            //Question
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();

            //Cart
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();

            return services;
        }
    }
}
