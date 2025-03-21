
using SPSS.Data;
using SPSS.Repositories;
using SPSS.Repository.Repositories.CategoryRepositoty;
using SPSS.Repository.Repositories.FeedbackRepository;
using SPSS.Repository.Repositories.AnswerRepository;
using SPSS.Repository.Repositories.CartItemService;
using SPSS.Repository.Repositories.OrderItemService;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.Repositories.PromotionRepository;
using SPSS.Repository.Repositories.QuestionRepository;
using SPSS.Repository.Repositories.User;
using SPSS.Repository.Repositories.BrandReposiotry;
using SPSS.Repository.Repositories.AnswerSheetRepository;
using SPSS.Repository.Repositories.AnswerDetailRepository;
using SPSS.Repository.Repositories.PaymentRepository;
using SPSS.Repository.Repositories.ResultRepository;
using SPSS.Repository.Repositories.SkinTypeRepository;
using SPSS.Repository.Repositories;
using SPSS.Repository.Repositories.BlogCategoryReposiotry;
using SPSS.Repository.Repositories.BlogRepository;
using SPSS.Repository.Repositories.BlogContentRepository;


namespace SPSS.Repository.UnitOfWork
{
    public class UnitOfWork(AppDbContext _context, IProductRepository _productRepository
        , IQuestionRepository _questionRepository, IFeedbackRepository _feedbackRepository
        , IPromotionRepository _promotionRepository, ICategoryRepository _categoryRepository
        , IAnswerRepository _answerRepository, IBrandRepository _brandRepository
        , IAnswerSheetRepository _answerSheetRepository, IAnswerDetailRepository _answerDetailRepository
        , ICartRepository _cartRepository, ICartItemRepository _cartItem
        , IOrderRepository _orderRepository, IOrderItemRepository _orderItemRepository
        , IUserRepository _userRepository, IPaymentRepository _paymentRepository, IResultRepository _resultRepository, ISkinTypeRepository _skinTypeRepository
        ,IConversationRepository _conversationRepository, IMessageRepository _messageRepository, IBlogCategoryReposiotry _blogCategoryReposiotry
        , IBlogRepository _blogRepository, IBlogContentRepository _blogContentRepository) : IUnitOfWork
    {
        public IProductRepository Products { get; } = _productRepository;
        public IQuestionRepository Questions { get; } = _questionRepository;
        public IFeedbackRepository Feedbacks { get; } = _feedbackRepository;
        public IPromotionRepository Promotions { get; } = _promotionRepository;
        public ICategoryRepository Categories { get; } = _categoryRepository;
        public IAnswerRepository Answers { get; } = _answerRepository;
        public IAnswerSheetRepository AnswerSheets { get; } = _answerSheetRepository;

        public IBrandRepository Brands { get; } = _brandRepository;
        public IAnswerDetailRepository AnswerDetails { get; } = _answerDetailRepository;
        public IResultRepository Results { get; } = _resultRepository;
        public ISkinTypeRepository SkinTypes { get; } = _skinTypeRepository;


        public ICartRepository Carts { get; } = _cartRepository;
        public ICartItemRepository CartItems { get; } = _cartItem;
        public IOrderRepository Orders { get; } = _orderRepository;
        public IOrderItemRepository OrderItems { get; } = _orderItemRepository;
        public IUserRepository Users { get; } = _userRepository;
        public IPaymentRepository Payments { get; } = _paymentRepository;
        public IConversationRepository Conversations { get; } = _conversationRepository;
        public IMessageRepository Messages { get; } = _messageRepository;
        public IBlogCategoryReposiotry BlogCategories { get; } = _blogCategoryReposiotry;
        public IBlogRepository Blogs { get; } = _blogRepository;
        public IBlogContentRepository BlogContents { get; } = _blogContentRepository;

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
