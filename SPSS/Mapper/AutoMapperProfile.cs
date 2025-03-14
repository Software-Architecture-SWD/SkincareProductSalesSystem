﻿using AutoMapper;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Entities;
using SPSS.Repository.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;

namespace SPSS.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductRequest, Product>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Question, QuestionResponse>();
            CreateMap<QuestionRequest, Question>().ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false));
            CreateMap<Feedback, FeedbackResponse>();
            CreateMap<FeedbackRequest, Feedback>();
            CreateMap<Promotion, PromotionResponse>();
            CreateMap<PromotionRequest, Promotion>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow)) 
                .ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false)); 
            CreateMap<Answer, AnswerResponse>();
            CreateMap<AnswerRequest, Answer>().ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false));
            CreateMap<BrandRequest, Brand>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Brand, BrandResponse>();
            CreateMap<AnswerSheet, AnswerSheetResponse>();
            CreateMap<AnswerSheetRequest, AnswerSheet>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false));
            CreateMap<AnswerDetailRequest, AnswerDetail>();
            CreateMap<AnswerDetail, AnswerDetailResponse>();
            CreateMap<Cart, CartResponse>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(src => src.AppUser.NormalizedUserName));
            CreateMap<CartItem, CartItemResponse>()
                .ForMember(ci => ci.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(ci => ci.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl));
            CreateMap<Result, ResultResponse>().ForMember(dest => dest.SkinTypeName, opt => opt.MapFrom(src => src.SkinType != null ? src.SkinType.Name : null)); ;
            CreateMap<ResultRequest, Result>().ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false));
            CreateMap<SkinType, SkinTypeResponse>();
            CreateMap<SkinTypeRequest, SkinType>().ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false));
            CreateMap<CategoryRequest, Category>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Category, CategoryResponse>();
        }
    }
}
