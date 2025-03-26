using Microsoft.AspNetCore.Http;
using SPSS.Service.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNPAY.NET.Models;

namespace SPSS.Service.Services.VNPayService
{
    public interface IVNPayService
    {
        Task<string> CreatePaymentUrl(double moneyToPay, string description, string ipAddress, int orderId);
        Task<PaymentResultResponse> ProcessIpnAction(IQueryCollection query);
        Task<string> ProcessPaymentCallback(IQueryCollection query);
    }
}
