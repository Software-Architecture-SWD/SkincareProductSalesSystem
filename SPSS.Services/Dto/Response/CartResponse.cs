using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Response
{
    public class CartResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal TotalAmount { get; set; }
        public int ItemsCount { get; set; }
    }
}
