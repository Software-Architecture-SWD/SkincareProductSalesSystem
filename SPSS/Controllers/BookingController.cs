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
    public class BookingController(ICalendarService _calendarService, IMapper _mapper) : ControllerBase
    {



        [HttpPost("book")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingInfoRequest bookingRequest)
        {
            try
            {
                var booking = _mapper.Map<BookingInfoRequest, BookingInfo>(bookingRequest);
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var eventId = await _calendarService.CreateEventAsync(booking, accessToken);

                // Update booking entity with event ID
                //booking.Id = eventId;
                booking.Status =(int) BookingStatus.Completed;

                return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        private IActionResult GetBooking(int id)
        {
            // Logic lấy booking (giữ nguyên)
            return Ok();
        }

    }
}
