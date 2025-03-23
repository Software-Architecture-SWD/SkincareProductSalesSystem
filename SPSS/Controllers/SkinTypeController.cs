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
    public class SkinTypeController(IMapper _mapper, ISkinTypeService _skinTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSkinTypeList(int page = 1, int pageSize = 10)
        {
            try
            {
                var (skinTypes, totalCount) = await _skinTypeService.GetPagedSkinTypesAsync(page, pageSize);
                if (!skinTypes.Any())
                {
                    return NotFound(new { message = "No skin types found." });
                }
                var skinTypeResponses = _mapper.Map<IEnumerable<SkinTypeResponse>>(skinTypes);
                return Ok(new { skinTypeResponses, totalCount, page, pageSize });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving skin types.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkinType([FromForm] SkinTypeRequest skinTypeRequest)
        {
            try
            {
                var skinType = _mapper.Map<SkinType>(skinTypeRequest);
                await _skinTypeService.AddAsync(skinType);
                var skinTypeResponse = _mapper.Map<SkinTypeResponse>(skinType);
                return Ok(skinTypeResponse);
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
                await _skinTypeService.SoftDeleteAsync(id);
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
                await _skinTypeService.RestoreAsync(id);
                return Ok(new { message = "Skin type restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while restoring the skin type.", error = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkinTypeById(int id)
        {
            try
            {
                var skinType = await _skinTypeService.GetByIdAsync(id);
                if (skinType == null)
                {
                    return NotFound(new { message = "Skin type not found." });
                }

                var response = _mapper.Map<SkinTypeResponse>(skinType);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving skin type.", error = ex.Message });
            }
        }
        [HttpGet("search")]
        public async Task<IActionResult> GetSkinTypeByName( string name)
        {
            try
            {
                var skinType = await _skinTypeService.GetByNameAsync(name);
                if (skinType == null)
                {
                    return NotFound(new { message = "Skin type not found." });
                }

                var response = _mapper.Map<SkinTypeResponse>(skinType);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving skin type.", error = ex.Message });
            }
        }
    }
}
