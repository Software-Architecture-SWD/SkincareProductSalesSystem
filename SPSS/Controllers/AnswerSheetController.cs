using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.AnswerSheetService;

namespace SPSS.API.Controllers
{
    [Route("answer-sheets")]
    [ApiController]
    public class AnswerSheetsController(IMapper mapper, IAnswerSheetService answerSheetService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAnswerSheet([FromForm] AnswerSheetRequest answerSheetRequest)
        {
            try
            {
                var answerSheet = mapper.Map<AnswerSheet>(answerSheetRequest);
                await answerSheetService.AddAsync(answerSheet);
                var answerSheetResponse = mapper.Map<AnswerSheetResponse>(answerSheet);
                return Ok(answerSheetResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while creating the answer sheet.",
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAnswerSheets(int page = 1, int pageSize = 10)
        {
            try
            {
                var (answerSheets, totalCount) = await answerSheetService.GetPagedAnswerSheetsAsync(page, pageSize);
                if (!answerSheets.Any())
                {
                    return NotFound(new { message = "No answer sheets found." });
                }

                var answerSheetResponses = mapper.Map<IEnumerable<AnswerSheetResponse>>(answerSheets);
                return Ok(new
                {
                    answerSheetResponses,
                    totalCount,
                    page,
                    pageSize
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving answer sheets.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerSheet(int id)
        {
            try
            {
                await answerSheetService.SoftDeleteAsync(id);
                return Ok(new { message = "Answer sheet deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while deleting the answer sheet.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> RestoreAnswerSheet(int id)
        {
            try
            {
                await answerSheetService.RestoreAsync(id);
                return Ok(new { message = "Answer sheet restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while restoring the answer sheet.",
                    error = ex.Message
                });
            }
        }

        [HttpPost("{id}/submit")]
        public async Task<IActionResult> SubmitAnswerSheet([FromBody] SubmitAnswerSheetRequest submitAnswerSheetRequest)
        {
            if (submitAnswerSheetRequest == null || submitAnswerSheetRequest.AnswerIds == null || submitAnswerSheetRequest.AnswerIds.Count == 0)
            {
                return BadRequest(new { message = "AnswerSheetId and AnswerIds are required." });
            }

            try
            {
                var (skinType, totalPoints) = await answerSheetService.SubmitAnswerSheetsAsync(
                    submitAnswerSheetRequest.AnswerSheetId,
                    submitAnswerSheetRequest.AnswerIds
                );

                return Ok(new
                {
                    skinType,
                    totalPoints
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while submitting the answer sheet.",
                    error = ex.Message
                });
            }
        }
    }
}
