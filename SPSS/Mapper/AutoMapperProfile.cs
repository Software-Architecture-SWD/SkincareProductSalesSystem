using AutoMapper;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Entities;
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
        }
    }
}
