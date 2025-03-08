using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SPSS.Services;
using SPSS.Dto.Account;
using System;

namespace SPSS.Controllers
{
    [Route("email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("otp/send")]
        public async Task<IActionResult> SendOTP()
        {
            try
            {
                var result = await _emailService.GenerateAndSendOTP(HttpContext);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail(string userId, string senderId, string content)
        {
            try
            {
                await _emailService.SendEmail(userId, senderId, content);
                return Ok("Email sent");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("otp/verify")]
        public async Task<IActionResult> VerifyOTP([FromBody] OTPVerificationRequest request)
        {
            try
            {
                var result = await _emailService.VerifyOTP(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
