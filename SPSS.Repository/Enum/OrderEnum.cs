using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Enum
{
    public enum OrderStatus
    {
        Pending = 1,
        ProcessingPayment = 2,
        OnDelivery = 3,
        Completed = 4,
        Canceled = 5
    }
}
