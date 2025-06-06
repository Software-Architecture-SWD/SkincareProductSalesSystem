﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SPSS.Data;
using SPSS.Entities;
using System.Text;
using Microsoft.Extensions.Options;
using SPSS.Dto.Account;
using System.Collections.Concurrent;
using SPSS.Mapper;
using SPSS.Repository.Repositories.GenericRepository;
using SPSS.Service.Services.AuthService;
using SPSS.Service.Services.FirebaseStorageService;
using SPSS.Service.Services.EmailService;
using SPSS.Service.Services.ProductService;
using SPSS.Service.Services.VNPayService;
using SPSS.Repository.UnitOfWork;
using VNPAY.NET;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.Repositories.QuestionRepository;
using SPSS.Service.Services.QuestionService;
using Microsoft.AspNetCore.SignalR;
using SPSS.API.Hubs; // ✅ Import Hub

namespace SPSS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("SPSSDatabase")));

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            var secretKey = builder.Configuration["AppSettings:Token"];
            if (string.IsNullOrEmpty(secretKey))
                throw new InvalidOperationException("JWT Secret Key is missing in appsettings.json.");

            var key = Encoding.UTF8.GetBytes(secretKey);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["AppSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["AppSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true
                };
            })
            .AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Google:ClientId"];
                options.ClientSecret = builder.Configuration["Google:ClientSecret"];
                options.Scope.Add("https://www.googleapis.com/auth/calendar.events");
            });

            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            builder.Services.AddAuthorization();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // ✅ Thêm SignalR vào dịch vụ
            builder.Services.AddSignalR();

            // Cấu hình Email Service
            var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>()
                ?? throw new InvalidOperationException("Missing Email Configuration in appsettings.json.");

            builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));
            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddSingleton(new ConcurrentDictionary<string, OtpEntry>());
            builder.Services.AddTransient<IEmailService, EmailService>();
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSession();
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            // ✅ Đăng ký Hub cho SignalR
            app.MapHub<ChatHub>("/chatHub");

            app.Run();
        }
    }
}
