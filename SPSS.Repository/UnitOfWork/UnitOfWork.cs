using SPSS.Data;
using SPSS.Repository.Repositories.AnswerRepository;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.Repositories.QuestionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.UnitOfWork
{
    public class UnitOfWork(AppDbContext _context, IProductRepository _productRepository, IQuestionRepository _questionRepository, IAnswerRepository _answerRepository) : IUnitOfWork
    {
        public IProductRepository Products { get; } = _productRepository;
        public IQuestionRepository Questions { get; } = _questionRepository;
        public IAnswerRepository Answers { get; } = _answerRepository;

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
