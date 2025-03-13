using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Entities;
using SPSS.Service.Services.AnswerService;
using SPSS.Service.Services.ProductService;

namespace SPSS.API.Controllers
{
    [Route("answers")]
    [ApiController]
    public class AnswerController(IMapper _mapper, IAnswerService _answerService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Createanswer([FromForm] AnswerRequest answerRequest)
        {
            try
            {
                var answer = _mapper.Map<Answer>(answerRequest);
                await _answerService.AddAsync(answer);
                var answerResponse = _mapper.Map<AnswerResponse>(answer);
                return Ok(answerResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the answer.", error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAnswerList(int page = 1, int pageSize = 10)
        {
            try
            {
                var (answers, totalCount) = await _answerService.GetPagedAnswersAsync(page, pageSize);
                if (!answers.Any())
                {
                    return NotFound(new { message = "No prodanswersucts found." });
                }
                var answerResponses = _mapper.Map<IEnumerable<AnswerResponse>>(answers);
                return Ok(new { answerResponses, totalCount, page, pageSize });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving answers.", error = ex.Message });
            }
        }
        [HttpDelete("{id}/removal")]
        public async Task<IActionResult> SoftDeleteAnswer(int id)
        {
            try
            {
                await _answerService.SoftDeleteAsync(id);
                return Ok(new { message = "Answer soft-deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while soft-deleting the answer.", error = ex.Message });
            }
        }

        [HttpPut("{id}/restoration")]
        public async Task<IActionResult> RestoreAnswer(int id)
        {
            try
            {
                await _answerService.RestoreAsync(id);
                return Ok(new { message = "Answer restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while restoring the answer.", error = ex.Message });
            }
        }
    }
}
