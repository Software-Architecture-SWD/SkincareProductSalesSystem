using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Entities;
using SPSS.Service.Services.AnswerService;

namespace SPSS.API.Controllers
{
    [Route("answers")]
    [ApiController]
    public class AnswersController(IMapper mapper, IAnswerService answerService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAnswer([FromForm] AnswerRequest answerRequest)
        {
            try
            {
                var answer = mapper.Map<Answer>(answerRequest);
                await answerService.AddAsync(answer);
                var answerResponse = mapper.Map<AnswerResponse>(answer);
                return Ok(answerResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while creating the answer.",
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAnswers(int page = 1, int pageSize = 10)
        {
            try
            {
                var (answers, totalCount) = await answerService.GetPagedAnswersAsync(page, pageSize);
                if (!answers.Any())
                {
                    return NotFound(new { message = "No answers found." });
                }

                var answerResponses = mapper.Map<IEnumerable<AnswerResponse>>(answers);
                return Ok(new
                {
                    answerResponses,
                    totalCount,
                    page,
                    pageSize
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving answers.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            try
            {
                await answerService.SoftDeleteAsync(id);
                return Ok(new { message = "Answer deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while deleting the answer.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> RestoreAnswer(int id)
        {
            try
            {
                await answerService.RestoreAsync(id);
                return Ok(new { message = "Answer restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while restoring the answer.",
                    error = ex.Message
                });
            }
        }
    }
}
