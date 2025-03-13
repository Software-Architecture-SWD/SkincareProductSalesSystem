using SPSS.Data;
using SPSS.Repository.Repositories.CategoryRepositoty;
using SPSS.Repository.Repositories.FeedbackRepository;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.Repositories.PromotionRepository;
using SPSS.Repository.Repositories.QuestionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.UnitOfWork
{
    public class UnitOfWork(AppDbContext _context, IProductRepository _productRepository, IQuestionRepository _questionRepository, IFeedbackRepository _feedbackRepository, IPromotionRepository _promotionRepository, ICategoryRepository _categoryRepository) : IUnitOfWork
    {
        public IProductRepository Products { get; } = _productRepository;
        public IQuestionRepository Questions { get; } = _questionRepository;
        public IFeedbackRepository Feedbacks { get; } = _feedbackRepository;
        public IPromotionRepository Promotions { get; } = _promotionRepository;
        public ICategoryRepository Categories { get; } = _categoryRepository;

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
