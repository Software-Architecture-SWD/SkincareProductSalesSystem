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
            // ✅ Product
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductRequest, Product>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // ✅ Question
            CreateMap<Question, QuestionResponse>();
            CreateMap<QuestionRequest, Question>().ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false));

            // ✅ Feedback
            CreateMap<Feedback, FeedbackResponse>();
            CreateMap<FeedbackRequest, Feedback>();

            // ✅ Promotion
            CreateMap<Promotion, PromotionResponse>();
            CreateMap<PromotionRequest, Promotion>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false));

            // ✅ Answer
            CreateMap<Answer, AnswerResponse>();
            CreateMap<AnswerRequest, Answer>().ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false));

            // ✅ Brand
            CreateMap<BrandRequest, Brand>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Brand, BrandResponse>();

            // ✅ AnswerSheet
            CreateMap<AnswerSheet, AnswerSheetResponse>();
            CreateMap<AnswerSheetRequest, AnswerSheet>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false));

            // ✅ AnswerDetail
            CreateMap<AnswerDetailRequest, AnswerDetail>();
            CreateMap<AnswerDetail, AnswerDetailResponse>();

            // ✅ Cart
            CreateMap<Cart, CartResponse>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(src => src.AppUser.FullName));
            CreateMap<CartItem, CartItemResponse>()
                .ForMember(ci => ci.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(ci => ci.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl));

            // ✅ Result
            CreateMap<Result, ResultResponse>().ForMember(dest => dest.SkinTypeName, opt => opt.MapFrom(src => src.SkinType != null ? src.SkinType.Name : null));
            CreateMap<ResultRequest, Result>().ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false));

            // ✅ SkinType
            CreateMap<SkinType, SkinTypeResponse>();
            CreateMap<SkinTypeRequest, SkinType>().ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false));

            // ✅ Category
            CreateMap<CategoryRequest, Category>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Category, CategoryResponse>();

            // ✅ Order
            CreateMap<Order, OrderResponse>()
                .ForMember(o => o.UserName, opt => opt.MapFrom(src => src.AppUser.FullName));
            // 🔥 ✅ **Chat (Conversation & Message)**
            CreateMap<Conversation, ConversationResponse>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.UserId1))
                .ForMember(dest => dest.ExpertId, opt => opt.MapFrom(src => src.UserId2))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages));

            CreateMap<StartChatRequest, Conversation>()
                .ForMember(dest => dest.UserId1, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.UserId2, opt => opt.MapFrom(src => (string?)null)) // 🔥 Ban đầu chưa có Expert
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Message, MessageResponse>()
                .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.SenderId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<SendMessageRequest, Message>()
                .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.SenderId))
                .ForMember(dest => dest.ConversationId, opt => opt.MapFrom(src => src.ConversationId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<BookingInfoRequest, BookingInfo>();
            CreateMap<OrderItem, OrderItemResponse>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));

            // ✅ BlogCategory
            CreateMap<BlogCategory, BlogCategoryResponse>();
            CreateMap<BlogCategoryRequest, BlogCategory>()
                .ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            // ✅ Blog
            CreateMap<Blog, BlogResponse>();
            CreateMap<BlogRequest, Blog>()
                .ForMember(dest => dest.isDelete, opt => opt.MapFrom(src => false))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            // ✅ BlogContent
            CreateMap<BlogContent, BlogContentResponse>();
            CreateMap<BlogContentRequest, BlogContent>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Order, OrderFullResponse>()
                .ForMember(o => o.UserName, opt => opt.MapFrom(src => src.AppUser.FullName))
                .ForMember(o => o.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
        }
    }
}
