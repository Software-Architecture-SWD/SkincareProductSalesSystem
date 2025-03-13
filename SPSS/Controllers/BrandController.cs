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
    public class BrandController(IBrandService _brandService, IMapper _mapper) : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            try
            {
                var listBrand = await _brandService.GetAllAsync();
                if (listBrand == null)
                {
                    return NotFound(new { message = "No brands found." });
                }
                return Ok(listBrand);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving brands.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            try
            {
                var brand = await _brandService.GetByIdAsync(id);
                if (brand == null)
                {
                    return NotFound(new { message = "Brand not found." });
                }

                var brandResponse = _mapper.Map<BrandResponse>(brand);
                return Ok(brandResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the brand.", error = ex.Message });
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> SearchName(string name)
        {
            try
            {
                var brand = await _brandService.GetByNameAsync(name);
                if (brand == null)
                {
                    return NotFound(new { message = "Brand not found." });
                }

                var brandResponse = _mapper.Map<BrandResponse>(brand);
                return Ok(brandResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the brand.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, BrandRequest brandRequest)
        {
            try
            {
                var brand = await _brandService.GetByIdAsync(id);
                if (brand == null)
                {
                    return NotFound(new { message = "Brand not found." });
                }
                _mapper.Map(brandRequest, brand);
                await _brandService.UpdateAsync(id, brand);
                return Ok("Update successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the brand.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            try
            {
                var brand = await _brandService.GetByIdAsync(id);
                if (brand == null)
                {
                    return NotFound(new { message = "Brand not found." });
                }
                await _brandService.DeleteAsync(id);
                return Ok("Delete successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the brand.", error = ex.Message });
            }
        }
    }
}
