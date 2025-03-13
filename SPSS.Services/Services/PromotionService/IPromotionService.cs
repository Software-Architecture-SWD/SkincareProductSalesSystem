using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPSS.Service.Services.PromotionService
{
    public interface IPromotionService
    {
        Task<IEnumerable<Promotion>> GetAllAsync();
        Task<Promotion> GetByIdAsync(int id);
        Task AddAsync(Promotion entity);
        Task UpdateAsync(Promotion entity);
        Task DeleteAsync(int id); 
        Task RestoreAsync(int id); 
        Task<(IEnumerable<Promotion> Promotions, int TotalCount)> GetPagedPromotionsAsync(int page, int pageSize);
        Task ApplyPromotionAsync(string categoryName, string promotionCode);
        Task RemovePromotionAsync(string categoryName);
    }
}
