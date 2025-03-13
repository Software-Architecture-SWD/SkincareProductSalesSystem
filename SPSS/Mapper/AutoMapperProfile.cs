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
            CreateMap<ProductRequest, Product>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Question, QuestionResponse>();
            CreateMap<QuestionRequest, Question>();
            CreateMap<Feedback, FeedbackResponse>();
            CreateMap<FeedbackRequest, Feedback>();
            CreateMap<Promotion, PromotionResponse>();
            CreateMap<PromotionRequest, Promotion>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow)) 
                .ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false)); 
        }
    }
}
