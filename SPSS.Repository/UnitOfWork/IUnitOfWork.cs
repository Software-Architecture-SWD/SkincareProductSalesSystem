using SPSS.Repository.Repositories.BrandRepository;
using SPSS.Repository.Repositories.CategoryRepository;
using SPSS.Repository.Repositories.FeedbackRepository;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.Repositories.QuestionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IQuestionRepository Questions { get; }
        IFeedbackRepository Feedbacks { get; }
        IBrandRepository Brands { get; }
        ICategoryRepository Categories { get; }   

        Task<int> CompleteAsync();
        Task<int> SaveChangesAsync();
    }
}   