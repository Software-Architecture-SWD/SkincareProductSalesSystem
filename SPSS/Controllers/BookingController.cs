using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Repository.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Services.CalendarService;

namespace SPSS.API.Controllers
{
    [Route("bookings")]
    [ApiController]
    public class BookingController(ICalendarService _calendarService, IMapper _mapper) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateEvent(BookingInfoRequest b)
        {
            if (b == null)
            {
                return BadRequest("Event data is required.");
            }

            try
            {
                var bookingInfo = _mapper.Map<BookingInfo>(b);
                await _calendarService.CreateEventAsync(bookingInfo);
                return Ok("Event created successfully.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the event.");
            }
        }
    }
}
