using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.ResultService;

namespace SPSS.API.Controllers
{
    [Route("results")]
    [ApiController]
    public class ResultController(IMapper _mapper, IResultService _resultService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetResultList()
        {
            try
            {
                var results = await _resultService.GetAllAsync();
                if (!results.Any())
                {
                    return NotFound(new { message = "No results found." });
                }
                var resultResponses = _mapper.Map<IEnumerable<ResultResponse>>(results);
                return Ok(resultResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving results.", error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateResult([FromForm] ResultRequest request)
        {
            try
            {
                var result = _mapper.Map<Result>(request);
                await _resultService.AddAsync(result);
                var resultResponse = _mapper.Map<ResultResponse>(result);
                return Ok(resultResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the result.", error = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteResult(int id)
        {
            try
            {
                await _resultService.SoftDeleteAsync(id);
                return Ok(new { message = "Result soft-deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while soft-deleting the result.", error = ex.Message });
            }
        }
        [HttpPut("{id}/restore")]
        public async Task<IActionResult> RestoreResult(int id)
        {
            try
            {
                await _resultService.RestoreAsync(id);
                return Ok(new { message = "Result restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while restoring the result.", error = ex.Message });
            }
        }
    }
}
