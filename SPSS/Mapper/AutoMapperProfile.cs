using AutoMapper;
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
            CreateMap<ProductRequest, Product>();
            CreateMap<Question, QuestionResponse>();
            CreateMap<QuestionRequest, Question>();
            CreateMap<Feedback, FeedbackResponse>();
            CreateMap<FeedbackRequest, Feedback>();
            CreateMap<Product, ProductResponse>()
           .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName))  
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));     
        }
    }
}
