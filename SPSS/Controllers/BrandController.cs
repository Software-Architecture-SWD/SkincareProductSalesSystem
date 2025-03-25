using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.BrandService;
using SPSS.Service.Services.ProductService;

namespace SPSS.API.Controllers
{
    [Route("brands")]
    [ApiController]
    public class BrandsController(IBrandService brandService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                var brands = await brandService.GetAllAsync();
                if (brands == null || !brands.Any())
                {
                    return NotFound(new { message = "No brands found." });
                }

                var brandResponses = mapper.Map<IEnumerable<BrandResponse>>(brands);
                return Ok(brandResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving brands.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            try
            {
                var brand = await brandService.GetByIdAsync(id);
                if (brand == null)
                {
                    return NotFound(new { message = "Brand not found." });
                }

                var brandResponse = mapper.Map<BrandResponse>(brand);
                return Ok(brandResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving the brand.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBrandByName([FromQuery] string name)
        {
            try
            {
                var brand = await brandService.GetByNameAsync(name);
                if (brand == null)
                {
                    return NotFound(new { message = "Brand not found." });
                }

                var brandResponse = mapper.Map<BrandResponse>(brand);
                return Ok(brandResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving the brand.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] BrandRequest brandRequest)
        {
            try
            {
                var existingBrand = await brandService.GetByIdAsync(id);
                if (existingBrand == null)
                {
                    return NotFound(new { message = "Brand not found." });
                }

                mapper.Map(brandRequest, existingBrand);
                await brandService.UpdateAsync(id, existingBrand);
                return Ok(new { message = "Brand updated successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while updating the brand.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            try
            {
                var brand = await brandService.GetByIdAsync(id);
                if (brand == null)
                {
                    return NotFound(new { message = "Brand not found." });
                }

                await brandService.DeleteAsync(id);
                return Ok(new { message = "Brand deleted successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while deleting the brand.",
                    error = ex.Message
                });
            }
        }
    }
}
