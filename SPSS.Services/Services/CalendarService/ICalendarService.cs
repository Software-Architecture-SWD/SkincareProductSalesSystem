using SPSS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.CalendarService
{
    public interface ICalendarService
    {
        Task CreateEventAsync(BookingInfo b);
    }
}
