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
        public async Task<ActionResult<string>> CreatePaymentUrl(double moneyToPay, string description, int orderId)

        {
            try
            {
                var ipAddress = NetworkHelper.GetIpAddress(HttpContext);
                var paymentUrl = await vnPayService.CreatePaymentUrl(moneyToPay, description, ipAddress, orderId);
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
                return NotFound("Không tìm thấy thông tin thanh toán.");

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


        //[HttpGet("results")]
        //public async Task<ActionResult<string>> Callback()
        //{

        //    if (!Request.QueryString.HasValue)
        //    {
        //        return NotFound("Không tìm thấy thông tin thanh toán.");
        //    }

        //    try
        //    {
        //        var resultDescription = await _vnPayService.ProcessPaymentCallback(Request.Query);
        //        return Ok(resultDescription);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

    }
}
