using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.SkinTypeService;

namespace SPSS.API.Controllers
{
    [Route("skintypes")]
    [ApiController]
    public class SkinTypesController(IMapper mapper, ISkinTypeService skinTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPagedSkinTypes([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var (skinTypes, totalCount) = await skinTypeService.GetPagedSkinTypesAsync(page, pageSize);

                if (!skinTypes.Any())
                    return NotFound(new { message = "No skin types found." });

                var response = mapper.Map<IEnumerable<SkinTypeResponse>>(skinTypes);
                return Ok(new
                {
                    message = "Skin types retrieved successfully.",
                    data = response,
                    totalCount,
                    page,
                    pageSize
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving skin types.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkinTypeById(int id)
        {
            try
            {
                var skinType = await skinTypeService.GetByIdAsync(id);
                if (skinType == null)
                    return NotFound(new { message = "Skin type not found." });

                var response = mapper.Map<SkinTypeResponse>(skinType);
                return Ok(new { message = "Skin type retrieved successfully.", data = response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving skin type.", error = ex.Message });
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSkinTypeByName([FromQuery] string name)
        {
            try
            {
                var skinType = await skinTypeService.GetByNameAsync(name);
                if (skinType == null)
                    return NotFound(new { message = "Skin type not found." });

                var response = mapper.Map<SkinTypeResponse>(skinType);
                return Ok(new { message = "Skin type retrieved successfully.", data = response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving skin type.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkinType([FromForm] SkinTypeRequest request)
        {
            try
            {
                var skinType = mapper.Map<SkinType>(request);
                await skinTypeService.AddAsync(skinType);

                var response = mapper.Map<SkinTypeResponse>(skinType);
                return Ok(new { message = "Skin type created successfully.", data = response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the skin type.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteSkinType(int id)
        {
            try
            {
                await skinTypeService.SoftDeleteAsync(id);
                return Ok(new { message = "Skin type soft-deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while soft-deleting the skin type.", error = ex.Message });
            }
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> RestoreSkinType(int id)
        {
            try
            {
                await skinTypeService.RestoreAsync(id);
                return Ok(new { message = "Skin type restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while restoring the skin type.", error = ex.Message });
            }
        }
    }
}
