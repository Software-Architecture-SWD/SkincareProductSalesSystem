using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPSS.Service.Services.PromotionService;
using SPSS.Entities;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.ProductService;

namespace SPSS.API.Controllers
{
    [Route("promotions")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
        private readonly ILogger<PromotionController> _logger;
        private readonly IMapper _mapper;

        public PromotionController(IPromotionService promotionService, ILogger<PromotionController> logger, IMapper mapper)
        {
            _promotionService = promotionService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionResponse>>> GetAllPromotions()
        {
            try
            {
                var promotions = await _promotionService.GetAllAsync();
                var promotionResponses = _mapper.Map<IEnumerable<PromotionResponse>>(promotions); 
                return Ok(promotionResponses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all promotions.");
                return StatusCode(500, "An error occurred while retrieving promotions.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionResponse>> GetPromotionById(int id)
        {
            try
            {
                var promotion = await _promotionService.GetByIdAsync(id);
                if (promotion == null)
                {
                    return NotFound("Promotion not found.");
                }
                var promotionResponse = _mapper.Map<PromotionResponse>(promotion); 
                return Ok(promotionResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching promotion with ID {Id}", id);
                return StatusCode(500, "An error occurred while retrieving the promotion.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddPromotion([FromBody] PromotionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var promotion = _mapper.Map<Promotion>(request); 
                promotion.CreatedAt = DateTime.UtcNow; 

                await _promotionService.AddAsync(promotion);
                return CreatedAtAction(nameof(GetPromotionById), new { id = promotion.Id }, promotion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding promotion.");
                return StatusCode(500, "An error occurred while adding the promotion.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePromotion(int id, [FromBody] PromotionRequest request)
        {
            try
            {
                var existingPromotion = await _promotionService.GetByIdAsync(id);
                if (existingPromotion == null)
                {
                    return NotFound("Promotion not found.");
                }

                _mapper.Map(request, existingPromotion); 

                await _promotionService.UpdateAsync(existingPromotion);
                return Ok("Promotion updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating promotion with ID {Id}", id);
                return StatusCode(500, "An error occurred while updating the promotion.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            try
            {
                var promotion = await _promotionService.GetByIdAsync(id);
                if (promotion == null)
                {
                    return NotFound(new { message = "Promotion not found." });
                }

                await _promotionService.DeleteAsync(id);
                return Ok("Promotion deleted successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting promotion with ID {Id}", id);
                return StatusCode(500, new { message = "An error occurred while deleting the promotion.", error = ex.Message });
            }
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestorePromotion(int id)
        {
            try
            {
                var promotion = await _promotionService.GetByIdAsync(id);
                if (promotion == null)
                {
                    return NotFound(new { message = "Promotion not found." });
                }

                await _promotionService.RestoreAsync(id);
                return Ok(new { message = "Promotion restored successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring promotion with ID {Id}", id);
                return StatusCode(500, new { message = "An error occurred while restoring the promotion.", error = ex.Message });
            }
        }
        [HttpPost("apply-promotion-category")]
        public async Task<IActionResult> ApplyPromotionToCategory([FromQuery] string categoryName, [FromQuery] string promotionCode)
        {
            try
            {
                _logger.LogInformation("Applying promotion to category with name {CategoryName} and promotion code {PromotionCode}.", categoryName, promotionCode);

                // Gọi service để áp dụng khuyến mãi
                await _promotionService.ApplyPromotionAsync(categoryName, promotionCode);

                return Ok(new { message = "Promotion applied successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error applying promotion to category.");
                return StatusCode(500, new { message = "An error occurred while applying the promotion.", error = ex.Message });
            }
        }

        [HttpPost("apply-promotion-order")]
        public async Task<IActionResult> ApplyPromotionToOrder([FromQuery] int orderId, [FromQuery] string promotionCode)
        {
            try
            {
                _logger.LogInformation("Applying promotion to category with name {OrderId} and promotion code {PromotionCode}.", orderId, promotionCode);

                // Gọi service để áp dụng khuyến mãi
                await _promotionService.ApplyPromotionOrderAsync(orderId, promotionCode);

                return Ok(new { message = "Promotion applied successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error applying promotion to category.");
                return StatusCode(500, new { message = "An error occurred while applying the promotion.", error = ex.Message });
            }
        }

        [HttpPost("remove-promotion")]
        public async Task<IActionResult> RemovePromotionFromCategory([FromQuery] string categoryName)
        {
            try
            {
                _logger.LogInformation("Removing promotion from category with name {CategoryName}.", categoryName);

                
                await _promotionService.RemovePromotionAsync(categoryName);

                return Ok(new { message = "Promotion removed successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing promotion from category.");
                return StatusCode(500, new { message = "An error occurred while removing the promotion.", error = ex.Message });
            }
        }

    }
}
