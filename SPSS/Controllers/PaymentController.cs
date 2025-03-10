using Microsoft.AspNetCore.Mvc;
using SPSS.Service.Services.VNPayService;
using VNPAY.NET.Enums;
using VNPAY.NET.Models;
using VNPAY.NET.Utilities;

namespace SPSS.API.Controllers
{
    [Route("payments")]
    [ApiController]
    public class PaymentController(IVNPayService _vnPayService) : ControllerBase
    {
        [HttpGet("createPaymentUrl")]
        public async Task<ActionResult<string>> CreatePaymentUrl(double moneyToPay, string description)
        {
            try
            {
                var ipAddress = NetworkHelper.GetIpAddress(HttpContext);
                var paymentUrl = await _vnPayService.CreatePaymentUrl(moneyToPay, description, ipAddress);
                return Created(paymentUrl, paymentUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("IpnAction")]
        public async Task<ActionResult> IpnAction()
        {
            if (!Request.QueryString.HasValue)
            {
                return NotFound("Không tìm thấy thông tin thanh toán.");
            }

            try
            {
                var paymentResult = _vnPayService.ProcessIpnAction(Request.Query);

                if (paymentResult.IsCompleted)
                {
                    return Ok("Thanh toán thành công");
                }

                return BadRequest("Thanh toán thất bại");
            }
            catch (Exception)
            {
                return StatusCode(500, "Lỗi xử lý thanh toán.");
            }
        }

        [HttpGet("callback")]
        public async Task <ActionResult<string>> Callback()
        {

            if (!Request.QueryString.HasValue)
            {
                return NotFound("Không tìm thấy thông tin thanh toán.");
            }

            try
            {
                var resultDescription = await _vnPayService.ProcessPaymentCallback(Request.Query);
                return Ok(resultDescription);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}