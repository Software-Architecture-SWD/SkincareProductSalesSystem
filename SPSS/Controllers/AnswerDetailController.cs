using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.AnswerDetailService;

namespace SPSS.API.Controllers
{
    [Route("answer-details")]
    [ApiController]
    public class AnswerDetailsController(IMapper mapper, IAnswerDetailService answerDetailService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAnswerDetails()
        {
            try
            {
                var answerDetails = await answerDetailService.GetAllAsync();
                if (!answerDetails.Any())
                {
                    return NotFound(new { message = "No answer details found." });
                }

                var answerDetailResponses = mapper.Map<IEnumerable<AnswerDetailResponse>>(answerDetails);
                return Ok(answerDetailResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving answer details.",
                    error = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswerDetails([FromBody] AnswerDetailRequest answerDetailRequest)
        {
            try
            {
                if (answerDetailRequest == null || answerDetailRequest.AnswerIds == null || answerDetailRequest.AnswerIds.Count == 0)
                {
                    return BadRequest(new
                    {
                        message = "Invalid request. AnswerSheetId and list of AnswerIds are required."
                    });
                }

                var createdDetails = await answerDetailService.CreateAnswerDetailsAsync(
                    answerDetailRequest.AnswerSheetId,
                    answerDetailRequest.AnswerIds
                );

                var answerDetailResponses = mapper.Map<IEnumerable<AnswerDetailResponse>>(createdDetails);
                return Ok(answerDetailResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while creating the answer details.",
                    error = ex.Message
                });
            }
        }
    }
}
