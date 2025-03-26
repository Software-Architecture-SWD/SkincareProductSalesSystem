using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SPSS.Entities;
using SPSS.Repository.Enum;
using SPSS.Repository.UnitOfWork;
using SPSS.Service.Dto.Response;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public VNPayService(IVnpay vnpay, IConfiguration configuration, ILogger<VNPayService> logger, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _vnpay = vnpay;
            _configuration = configuration;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;

            _vnpay.Initialize(_configuration["Vnpay:TmnCode"], _configuration["Vnpay:HashSecret"], _configuration["Vnpay:BaseUrl"], _configuration["Vnpay:CallbackUrl"]);
        }

        public async Task<string> CreatePaymentUrl(double moneyToPay, string description, string ipAddress, int orderId)
        {
            try
            {
                _httpContextAccessor.HttpContext?.Session.SetInt32("OrderId", orderId);

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

        public async Task<PaymentResultResponse> ProcessIpnAction(IQueryCollection query)
        {
            if (query.Count == 0)
            {
                _logger.LogWarning("Không tìm thấy thông tin thanh toán.");
                throw new Exception("Không tìm thấy thông tin thanh toán.");

            }
            try
            {
                var paymentResult =  _vnpay.GetPaymentResult(query);
                var orderId = _httpContextAccessor.HttpContext?.Session.GetInt32("OrderId")??0;
                var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
                //var payment = await _unitOfWork.Payments.GetPaymentByOrderIdAsync(orderId);
                var orderResponse = _mapper.Map<OrderResponse>(order);

                var paymentResultResponse = new PaymentResultResponse
                {
                    PaymentResult = paymentResult,
                    Order = orderResponse
                };

                if (paymentResult.IsSuccess)
                {
                    _logger.LogInformation("Thanh toán thành công - PaymentId: {PaymentId}", paymentResult.PaymentId);
                    // TODO: Cập nhật trạng thái đơn hàng vào DB
                    order.Status = OrderStatus.Completed;
                    //add payemnt to db
                    var payment = new Payment
                    {
                        OrderId = order.Id,
                        PaymentStatus = PaymentStatus.Success,
                        TransactionId = paymentResult.VnpayTransactionId.ToString(),
                        PaymentDate = paymentResult.Timestamp,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _unitOfWork.Payments.AddPaymentAsync(payment);
                }
                else
                {
                    _logger.LogWarning("Thanh toán thất bại - PaymentId: {PaymentId}", paymentResult.PaymentId);
                    // TODO: Xử lý khi thanh toán thất bại (ví dụ: hủy đơn hàng)
                    order.Status = OrderStatus.Canceled;
                    //payment.PaymentStatus = PaymentStatus.Failed;
                    //payment.CreatedAt = DateTime.UtcNow;

                }

                return paymentResultResponse;

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
