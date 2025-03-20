using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Logging;
using SPSS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SPSS.Service.Services.CalendarService
{
    public class CalendarService(ILogger<CalendarService> _logger) : ICalendarService
    {
        public async Task<string> CreateEventAsync(BookingInfo booking, string accessToken)
        {
            try
            {
                // Khởi tạo Google Calendar Service (THƯ VIỆN NGOÀI)
                var googleCredential = GoogleCredential.FromAccessToken(accessToken)
                    .CreateScoped(new[]{ "https://www.googleapis.com/auth/calendar.events" });

                // Sử dụng FULL NAMESPACE để tránh nhầm lẫn
                var googleCalendarService = new Google.Apis.Calendar.v3.CalendarService(
                    new Google.Apis.Services.BaseClientService.Initializer
                    {
                        HttpClientInitializer = googleCredential,
                        ApplicationName = "SPSS"
                    });

                // Tạo event
                var newEvent = new Event
                {
                    Summary = $"Booking with Expert {booking.ExpertId}",
                    Description = booking.Special_requests,
                    Start = new EventDateTime { DateTime = booking.Start_time, TimeZone = "Asia/Ho_Chi_Minh" },
                    End = new EventDateTime { DateTime = booking.End_time, TimeZone = "Asia/Ho_Chi_Minh" }
                };

                var createdEvent = await googleCalendarService.Events.Insert(newEvent, "primary").ExecuteAsync();
                return createdEvent.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Google Calendar error");
                throw new ApplicationException("Calendar event creation failed", ex);
            }
        }
    }
}
