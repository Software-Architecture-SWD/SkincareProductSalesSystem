using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.AnswerDetailService;

namespace SPSS.API.Controllers
{
    [Route("answerdetails")]
    [ApiController]
    public class AnswerDetailController(IMapper _mapper, IAnswerDetailService _answerDetailService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAnswerDetailList()
        {
            try
            {
                var answerDetails = await _answerDetailService.GetAllAsync();
                if (!answerDetails.Any())
                {
                    return NotFound(new { message = "No answer details found." });
                }
                var answerDetailResponses = _mapper.Map<IEnumerable<AnswerDetailResponse>>(answerDetails);
                return Ok(answerDetailResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving answer details.", error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnswerDetail([FromBody] AnswerDetailRequest request)
        {
            try
            {
                if (request == null || request.AnswerIds == null || request.AnswerIds.Count == 0)
                    return BadRequest(new { message = "Invalid request. AnswerSheetId and list of AnswerIds are required." });

                var createdDetails = await _answerDetailService.CreateAnswerDetailsAsync(request.AnswerSheetId, request.AnswerIds);
                var answerDetailResponse = _mapper.Map<IEnumerable<AnswerDetailResponse>>(createdDetails);
                return Ok(answerDetailResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the answer detail.", error = ex.Message });
            }
        }
    }
}
