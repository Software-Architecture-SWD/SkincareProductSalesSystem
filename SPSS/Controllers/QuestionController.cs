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
        public async Task<IActionResult> GetQuestionList()
        {
            try
            {
                var listQuestion = await _questionService.GetAllAsync();
                if (listQuestion == null)
                {
                    return NotFound(new { message = "No questions found." });
                }
                var questionResponses = _mapper.Map<IEnumerable<QuestionResponse>>(listQuestion);
                return Ok(questionResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving questions.", error = ex.Message });
            }
        }
    }
}
