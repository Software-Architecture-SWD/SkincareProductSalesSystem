using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Entities;
using SPSS.Service.Services.QuestionService;

namespace SPSS.API.Controllers
{
    [Route("questions")]
    [ApiController]
    public class QuestionsController(IMapper mapper, IQuestionService questionService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromForm] QuestionRequest questionRequest)
        {
            try
            {
                var question = mapper.Map<Question>(questionRequest);
                await questionService.AddAsync(question);

                var questionResponse = mapper.Map<QuestionResponse>(question);
                return Ok(new { message = "Question created successfully.", data = questionResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while creating the question.",
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedQuestions([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var (questions, totalCount) = await questionService.GetPagedQuestionsAsync(page, pageSize);

                if (!questions.Any())
                    return NotFound(new { message = "No questions found." });

                var questionResponses = mapper.Map<IEnumerable<QuestionResponse>>(questions);
                return Ok(new
                {
                    message = "Questions retrieved successfully.",
                    data = questionResponses,
                    totalCount,
                    page,
                    pageSize
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving questions.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteQuestion(int id)
        {
            try
            {
                await questionService.SoftDeleteAsync(id);
                return Ok(new { message = "Question soft-deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while soft-deleting the question.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> RestoreQuestion(int id)
        {
            try
            {
                await questionService.RestoreAsync(id);
                return Ok(new { message = "Question restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while restoring the question.",
                    error = ex.Message
                });
            }
        }
    }
}
