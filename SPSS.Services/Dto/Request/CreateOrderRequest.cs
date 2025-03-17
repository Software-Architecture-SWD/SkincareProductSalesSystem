using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Request
{
    public class CreateOrderRequest
    {
        public List<int> CartItemIds { get; set; }
    }

}
