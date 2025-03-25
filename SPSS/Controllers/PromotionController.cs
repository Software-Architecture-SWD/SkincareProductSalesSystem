using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPSS.Service.Services.PromotionService;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;

namespace SPSS.API.Controllers
{
    [Route("promotions")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionService promotionService;
        private readonly ILogger<PromotionsController> logger;
        private readonly IMapper mapper;

        public PromotionsController(IPromotionService promotionService, ILogger<PromotionsController> logger, IMapper mapper)
        {
            this.promotionService = promotionService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPromotions()
        {
            try
            {
                var promotions = await promotionService.GetAllAsync();
                var responses = mapper.Map<IEnumerable<PromotionResponse>>(promotions);
                return Ok(new { message = "Promotions retrieved successfully.", data = responses });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching all promotions.");
                return StatusCode(500, new { message = "An error occurred while retrieving promotions.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromotionById(int id)
        {
            try
            {
                var promotion = await promotionService.GetByIdAsync(id);
                if (promotion == null)
                    return NotFound(new { message = "Promotion not found." });

                var response = mapper.Map<PromotionResponse>(promotion);
                return Ok(new { message = "Promotion retrieved successfully.", data = response });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching promotion with ID {Id}", id);
                return StatusCode(500, new { message = "An error occurred while retrieving the promotion.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPromotion([FromBody] PromotionRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid input.", errors = ModelState });

            try
            {
                var promotion = mapper.Map<Promotion>(request);
                promotion.CreatedAt = DateTime.UtcNow;

                await promotionService.AddAsync(promotion);

                var response = mapper.Map<PromotionResponse>(promotion);
                return CreatedAtAction(nameof(GetPromotionById), new { id = promotion.Id }, new { message = "Promotion created successfully.", data = response });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding promotion.");
                return StatusCode(500, new { message = "An error occurred while adding the promotion.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePromotion(int id, [FromBody] PromotionRequest request)
        {
            try
            {
                var existing = await promotionService.GetByIdAsync(id);
                if (existing == null)
                    return NotFound(new { message = "Promotion not found." });

                mapper.Map(request, existing);
                await promotionService.UpdateAsync(existing);

                return Ok(new { message = "Promotion updated successfully." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating promotion with ID {Id}", id);
                return StatusCode(500, new { message = "An error occurred while updating the promotion.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            try
            {
                var promotion = await promotionService.GetByIdAsync(id);
                if (promotion == null)
                    return NotFound(new { message = "Promotion not found." });

                await promotionService.DeleteAsync(id);
                return Ok(new { message = "Promotion deleted successfully." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deleting promotion with ID {Id}", id);
                return StatusCode(500, new { message = "An error occurred while deleting the promotion.", error = ex.Message });
            }
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> RestorePromotion(int id)
        {
            try
            {
                var promotion = await promotionService.GetByIdAsync(id);
                if (promotion == null)
                    return NotFound(new { message = "Promotion not found." });

                await promotionService.RestoreAsync(id);
                return Ok(new { message = "Promotion restored successfully." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error restoring promotion with ID {Id}", id);
                return StatusCode(500, new { message = "An error occurred while restoring the promotion.", error = ex.Message });
            }
        }

        [HttpPost("apply-to-category")]
        public async Task<IActionResult> ApplyPromotionToCategory([FromQuery] string categoryName, [FromQuery] string promotionCode)
        {
            try
            {
                logger.LogInformation("Applying promotion '{PromotionCode}' to category '{CategoryName}'", promotionCode, categoryName);
                await promotionService.ApplyPromotionAsync(categoryName, promotionCode);
                return Ok(new { message = "Promotion applied to category successfully." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error applying promotion to category.");
                return StatusCode(500, new { message = "An error occurred while applying the promotion.", error = ex.Message });
            }
        }

        [HttpPost("apply-to-order")]
        public async Task<IActionResult> ApplyPromotionToOrder([FromQuery] int orderId, [FromQuery] string promotionCode)
        {
            try
            {
                logger.LogInformation("Applying promotion '{PromotionCode}' to order ID {OrderId}", promotionCode, orderId);
                await promotionService.ApplyPromotionOrderAsync(orderId, promotionCode);
                return Ok(new { message = "Promotion applied to order successfully." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error applying promotion to order.");
                return StatusCode(500, new { message = "An error occurred while applying the promotion to the order.", error = ex.Message });
            }
        }

        [HttpPost("remove-from-category")]
        public async Task<IActionResult> RemovePromotionFromCategory([FromQuery] string categoryName)
        {
            try
            {
                logger.LogInformation("Removing promotion from category '{CategoryName}'", categoryName);
                await promotionService.RemovePromotionAsync(categoryName);
                return Ok(new { message = "Promotion removed from category successfully." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error removing promotion from category.");
                return StatusCode(500, new { message = "An error occurred while removing the promotion.", error = ex.Message });
            }
        }
    }
}
