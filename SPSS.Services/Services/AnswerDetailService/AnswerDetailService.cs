using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.AnswerDetailService
{
    public class AnswerDetailService(IUnitOfWork _unitOfWork, ILogger<AnswerDetailService> _logger) : IAnswerDetailService
    {
        public async Task<IEnumerable<AnswerDetail>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all AnswerDetails.");
                return await _unitOfWork.AnswerDetails.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all AnswerDetails.");
                throw new Exception("An error occurred while retrieving AnswerDetails.", ex);
            }
        }
        public async Task AddAsync(AnswerDetail p)
        {
            try
            {
                _logger.LogInformation("Adding a new AnswerDetail");
                await _unitOfWork.AnswerDetails.AddAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding AnswerDetail");
                throw;
            }
        }
        public async Task UpdateAsync(AnswerDetail p)
        {
            try
            {
                _logger.LogInformation("Updating AnswerDetail");
                await _unitOfWork.AnswerDetails.UpdateAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating AnswerDetail");
                throw;
            }
        }
        public async Task DeleteAsync(AnswerDetail p)
        {
            try
            {
                _logger.LogInformation("Deleting AnswerDetail");
                await _unitOfWork.AnswerDetails.DeleteAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting AnswerDetail");
                throw;
            }
        }
        public async Task<IEnumerable<AnswerDetail>> CreateAnswerDetailsAsync(int answerSheetId, List<int> answerIds)
        {
            try
            {
                _logger.LogInformation("Creating AnswerDetails for AnswerSheet {AnswerSheetId}", answerSheetId);
                var answerDetails = new List<AnswerDetail>();
                foreach (var answerId in answerIds)
                {
                    var answerDetail = new AnswerDetail
                    {
                        AnswerSheetId = answerSheetId,
                        AnswerId = answerId
                    };
                    answerDetails.Add(answerDetail);
                }
                await _unitOfWork.AnswerDetails.AddRangeAsync(answerDetails);
                return answerDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating AnswerDetails for AnswerSheet {AnswerSheetId}", answerSheetId);
                throw;
            }
        }
    }  
}
