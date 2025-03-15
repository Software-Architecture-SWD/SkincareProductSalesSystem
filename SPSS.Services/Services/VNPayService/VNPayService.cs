using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNPAY;
using VNPAY.NET;
using VNPAY.NET.Enums;
using VNPAY.NET.Models;
using VNPAY.NET.Utilities;
namespace SPSS.Service.Services.VNPayService
{
    public class VNPayService : IVNPayService
    {
        private readonly IVnpay _vnpay;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ILogger<VNPayService> _logger;

        public VNPayService(IVnpay vnpay, IConfiguration configuration, ILogger<VNPayService> logger, IUnitOfWork unitOfWork)
        {
            _vnpay = vnpay;
            _configuration = configuration;
            _logger = logger;
            _unitOfWork = unitOfWork;

            _vnpay.Initialize(_configuration["Vnpay:TmnCode"], _configuration["Vnpay:HashSecret"], _configuration["Vnpay:BaseUrl"], _configuration["Vnpay:CallbackUrl"]);
        }

        public async Task<string> CreatePaymentUrl(double moneyToPay, string description, string ipAddress)
        {
            try
            {
                var request = new PaymentRequest
                {
                    PaymentId = DateTime.Now.Ticks,
                    Money = moneyToPay,
                    Description = description,
                    IpAddress = ipAddress,
                    BankCode = BankCode.ANY,
                    CreatedDate = DateTime.Now,
                    Currency = Currency.VND,
                    Language = DisplayLanguage.Vietnamese
                };

                _logger.LogInformation("Creating payment URL for PaymentId: {PaymentId}, Amount: {Amount}, IP: {IpAddress}",
                    request.PaymentId, request.Money, request.IpAddress);

                var paymentUrl = _vnpay.GetPaymentUrl(request);

                _logger.LogInformation("Payment URL created successfully: {PaymentUrl}", paymentUrl);

                return paymentUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating payment URL for amount {Amount}", moneyToPay);
                throw new Exception("Failed to create payment URL.", ex);
            }
        }

        public async Task<PaymentResult> ProcessIpnAction(IQueryCollection query, int paymentId)
        {
            if (query.Count == 0)
            {
                _logger.LogWarning("Không tìm thấy thông tin thanh toán.");
                throw new Exception("Không tìm thấy thông tin thanh toán.");

            }
            try
            {
                var paymentResult =  _vnpay.GetPaymentResult(query);
                var payment = await _unitOfWork.Payments.GetPaymentByIdAsync(paymentId);

                if (paymentResult.IsSuccess)
                {
                    _logger.LogInformation("Thanh toán thành công - PaymentId: {PaymentId}", paymentResult.PaymentId);
                    // TODO: Cập nhật trạng thái đơn hàng vào DB
                   
                    payment.PaymentStatus = PaymentStatus.Success;
                    payment.TransactionId = paymentResult.VnpayTransactionId.ToString();
                    payment.PaymentDate = paymentResult.Timestamp;
                    payment.CreatedAt = DateTime.UtcNow;


                }
                else
                {
                    _logger.LogWarning("Thanh toán thất bại - PaymentId: {PaymentId}", paymentResult.PaymentId);
                    // TODO: Xử lý khi thanh toán thất bại (ví dụ: hủy đơn hàng)
                    payment.PaymentStatus = PaymentStatus.Failed;
                    payment.CreatedAt = DateTime.UtcNow;


                }

                return paymentResult;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xử lý IPN từ VNPAY.");
                throw new Exception("Lỗi xử lý thanh toán.", ex);
            }

        }

        public async Task<string> ProcessPaymentCallback(IQueryCollection query)
        {
            _logger.LogInformation("Nhận Callback từ VNPAY với query: {Query}", query.ToString());

            if (!query.Any())
            {
                _logger.LogWarning("Không có dữ liệu trong query.");
                throw new ArgumentException("Không tìm thấy thông tin thanh toán.");
            }

            try
            {
                var paymentResult = _vnpay.GetPaymentResult(query);
                var resultDescription = $"{paymentResult.PaymentResponse.Description}. {paymentResult.TransactionStatus.Description}.";

                if (paymentResult.IsSuccess)
                {
                    _logger.LogInformation("Thanh toán thành công - PaymentId: {PaymentId}", paymentResult.PaymentId);
                }
                else
                {
                    _logger.LogWarning("Thanh toán thất bại - PaymentId: {PaymentId}, Lý do: {Message}",
                        paymentResult.PaymentId, resultDescription);
                }

                return resultDescription;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xử lý callback từ VNPAY.");
                throw new Exception("Lỗi trong quá trình xử lí thanh toán", ex);
            }
        }
    }
}
