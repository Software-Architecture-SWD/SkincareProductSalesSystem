using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.AnswerSheetService;

namespace SPSS.API.Controllers
{
    [Route("answersheet")]
    [ApiController]
    public class AnswerSheetController(IMapper _mapper, IAnswerSheetService _answerSheetService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAnswerSheet([FromForm] AnswerSheetRequest answerSheetRequest)
        {
            try
            {
                var answerSheet = _mapper.Map<AnswerSheet>(answerSheetRequest);
                await _answerSheetService.AddAsync(answerSheet);
                var answerSheetResponse = _mapper.Map<AnswerSheetResponse>(answerSheet);
                return Ok(answerSheetResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the answer sheet.", error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAnswerSheetList(int page = 1, int pageSize = 10)
        {
            try
            {
                var (answerSheets, totalCount) = await _answerSheetService.GetPagedAnswerSheetsAsync(page, pageSize);
                if (!answerSheets.Any())
                {
                    return NotFound(new { message = "No answer sheets found." });
                }
                var answerSheetResponses = _mapper.Map<IEnumerable<AnswerSheetResponse>>(answerSheets);
                return Ok(new { answerSheetResponses, totalCount, page, pageSize });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving answer sheets.", error = ex.Message });
            }
        }
        [HttpDelete("{id}/removal")]
        public async Task<IActionResult> SoftDeleteAnswerSheet(int id)
        {
            try
            {
                await _answerSheetService.SoftDeleteAsync(id);
                return Ok(new { message = "Answer sheet soft-deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while soft-deleting the answer sheet.", error = ex.Message });
            }
        }

        [HttpPut("{id}/restoration")]
        public async Task<IActionResult> RestoreAnswerSheet(int id)
        {
            try
            {
                await _answerSheetService.RestoreAsync(id);
                return Ok(new { message = "Answer sheet restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while restoring the answer sheet.", error = ex.Message });
            }
        }
    }
}
