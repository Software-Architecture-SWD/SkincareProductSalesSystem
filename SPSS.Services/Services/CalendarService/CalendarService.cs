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
    public class CalendarService : ICalendarService
    {
        private readonly Google.Apis.Calendar.v3.CalendarService _googleCalendarService;
        private readonly ILogger<CalendarService> _logger;
        private readonly IConfiguration _configuration;

        public CalendarService(ILogger<CalendarService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _googleCalendarService = InitializeServiceAsync().GetAwaiter().GetResult();
        }


        private async Task<Google.Apis.Calendar.v3.CalendarService> InitializeServiceAsync()
        {
            try
            {
                var clientId = _configuration["Google:ClientId"];
                var clientSecret = _configuration["Google:ClientSecret"];
                var applicationName = _configuration["Google:ApplicationName"];
                var user = _configuration["Google:User"];

                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret },
                    new[] { "https://www.googleapis.com/auth/calendar" },
                    user,
                    CancellationToken.None,
                    new FileDataStore("token.json", true)
                );

                _logger.LogInformation("Google Calendar authentication successful.");

                return new Google.Apis.Calendar.v3.CalendarService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = applicationName
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize Google Calendar service.");
                throw;
            }
        }

        public async Task CreateEventAsync(BookingInfo b)
        {
            try
            {
                var calendarId = _configuration["Google:CalendarId"];
                var newEvent = new Event
                {
                    //Summary = calendarEvent.Summary,
                    //Location = calendarEvent.Location,
                    Description = b.Special_requests,
                    Start = new EventDateTime
                    {
                        DateTime = b.Start_time,
                        TimeZone = "Asia/Ho_Chi_Minh"
                    },
                    End = new EventDateTime
                    {
                        DateTime = b.End_time,
                        TimeZone = "Asia/Ho_Chi_Minh"
                    }
                };

                await _googleCalendarService.Events.Insert(newEvent, calendarId).ExecuteAsync();
                _logger.LogInformation("Event created successfully: {Summary}", b.Special_requests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create event: {Summary}", b.Special_requests);
                throw;
            }
        }
    }
}
