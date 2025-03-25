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
    public class ResultsController(IMapper mapper, IResultService resultService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllResults()
        {
            try
            {
                var results = await resultService.GetAllAsync();

                if (!results.Any())
                {
                    return NotFound(new { message = "No results found." });
                }

                var response = mapper.Map<IEnumerable<ResultResponse>>(results);
                return Ok(new { message = "Results retrieved successfully.", data = response });
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
                var result = mapper.Map<Result>(request);
                await resultService.AddAsync(result);

                var response = mapper.Map<ResultResponse>(result);
                return Ok(new { message = "Result created successfully.", data = response });
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
                await resultService.SoftDeleteAsync(id);
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
                await resultService.RestoreAsync(id);
                return Ok(new { message = "Result restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while restoring the result.", error = ex.Message });
            }
        }
    }
}
