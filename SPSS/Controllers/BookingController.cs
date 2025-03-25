using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Repository.Entities;
using SPSS.Repository.Enum;
using SPSS.Service.Dto.Request;
using SPSS.Service.Services.CalendarService;

namespace SPSS.API.Controllers
{
    [Route("bookings")]
    [ApiController]
    public class BookingsController(ICalendarService calendarService, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingInfoRequest bookingRequest)
        {
            try
            {
                var booking = mapper.Map<BookingInfo>(bookingRequest);
                var accessToken = await HttpContext.GetTokenAsync("access_token");

                var eventId = await calendarService.CreateEventAsync(booking, accessToken);

                // Giả lập cập nhật trạng thái booking
                booking.Status = (int)BookingStatus.Completed;

                return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, booking);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }

        // Đặt lại tên method để chuẩn RESTful nếu muốn dùng trong CreatedAtAction
        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            // Dummy response – cần thay bằng service thực tế nếu áp dụng
            return Ok(new { message = $"Return booking with id = {id}" });
        }
    }
}
