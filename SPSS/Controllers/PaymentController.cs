using Microsoft.AspNetCore.Mvc;
using SPSS.Service.Services.VNPayService;
using VNPAY.NET.Utilities;

namespace SPSS.API.Controllers
{
    [Route("payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IVNPayService vnPayService;

        public PaymentsController(IVNPayService vnPayService)
        {
            this.vnPayService = vnPayService;
        }

        /// <summary>
        /// Tạo URL thanh toán VNPay
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> CreatePaymentUrl([FromQuery] double moneyToPay, [FromQuery] string description, [FromQuery] int paymentId)
        {
            try
            {
                var ipAddress = NetworkHelper.GetIpAddress(HttpContext);
                var paymentUrl = await vnPayService.CreatePaymentUrl(moneyToPay, description, ipAddress, paymentId);
                return Created(paymentUrl, new { message = "Payment URL created successfully.", data = paymentUrl });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to create payment URL.", error = ex.Message });
            }
        }

        /// <summary>
        /// Xử lý IPN từ VNPay (gửi từ server VNPay)
        /// </summary>
        [HttpGet("result")]
        public IActionResult ProcessIpnResult()
        {
            if (!Request.QueryString.HasValue)
            {
                return NotFound(new { message = "Không tìm thấy thông tin thanh toán." });
            }

            try
            {
                var paymentResult = vnPayService.ProcessIpnAction(Request.Query);

                if (paymentResult.IsCompleted)
                {
                    return Ok(new { message = "Payment successful.", data = paymentResult });
                }

                return BadRequest(new { message = "Thanh toán thất bại.", data = paymentResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi xử lý thanh toán.", error = ex.Message });
            }
        }

        /// <summary>
        /// Callback từ VNPay sau khi thanh toán (trả về trình duyệt người dùng)
        /// </summary>
        [HttpGet("results")]
        public async Task<IActionResult> ProcessPaymentCallback()
        {
            if (!Request.QueryString.HasValue)
            {
                return NotFound(new { message = "Không tìm thấy thông tin thanh toán." });
            }

            try
            {
                var resultDescription = await vnPayService.ProcessPaymentCallback(Request.Query);
                return Ok(new { message = "Payment callback handled successfully.", data = resultDescription });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi xử lý callback.", error = ex.Message });
            }
        }
    }
}
