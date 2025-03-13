using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Services.QuestionService;

namespace SPSS.API.Controllers
{
    [Route("questions")]
    [ApiController]
    public class QuestionController( IMapper _mapper, IQuestionService _questionService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromForm] QuestionRequest questionRequest)
        {
            try
            {
                var question = _mapper.Map<Question>(questionRequest);
                await _questionService.AddAsync(question);
                var questionResponse = _mapper.Map<QuestionResponse>(question);
                return Ok(questionResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the question.", error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetQuestionList(int page = 1, int pageSize = 10)
        {
            try
            {
                var (questions, totalCount) = await _questionService.GetPagedQuestionsAsync(page, pageSize);
                if (!questions.Any())
                {
                    return NotFound(new { message = "No questions found." });
                }
                var questionResponses = _mapper.Map<IEnumerable<QuestionResponse>>(questions);
                return Ok(new { questionResponses, totalCount, page, pageSize});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving questions.", error = ex.Message });
            }
        }
        [HttpDelete("{id}/removal")]
        public async Task<IActionResult> SoftDeleteQuestion(int id)
        {
            try
            {
                await _questionService.SoftDeleteAsync(id);
                return Ok(new { message = "Question soft-deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while soft-deleting the question.", error = ex.Message });
            }
        }

        [HttpPut("{id}/restoration")]
        public async Task<IActionResult> RestoreQuestion(int id)
        {
            try
            {
                await _questionService.RestoreAsync(id);
                return Ok(new { message = "Question restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while restoring the question.", error = ex.Message });
            }
        }
    }
}
