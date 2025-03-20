using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPSS.Dto;
using SPSS.Dto.Account;
using SPSS.Service.Services.AuthService;
using System.Security.Claims;

namespace SPSS.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                return BadRequest(new { message = "All fields (Username, Password, Email, FullName, PhoneNumber) are required." });
            }

            try
            {
                var user = await authService.RegisterAsync(request);
                if (user == null)
                    return Conflict(new { message = "Registration failed. User may already exist." });

                return Ok(new
                {
                    user.Id,
                    user.UserName,
                    user.EmailConfirmed,
                    user.FullName,
                    user.PhoneNumber,
                    message = "Register successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpPost("register-customer")]
        public async Task<IActionResult> RegisterWithRole([FromBody] UserDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                return BadRequest(new { message = "All fields (Username, Password, Email, FullName, PhoneNumber) are required." });
            }

            try
            {
                var user = await authService.RegisterWithRoleAsync(request);
                if (user == null)
                    return Conflict(new { message = "Registration failed. User may already exist." });

                return Ok(new
                {
                    user.Id,
                    user.UserName,
                    user.EmailConfirmed,
                    user.FullName,
                    user.PhoneNumber,
                    Role = "Customer",
                    message = "User registered successfully with role 'Customer'."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { message = "Username and password cannot be empty." });

            try
            {
                var result = await authService.LoginAsync(request);
                if (result == null)
                    return Unauthorized(new { message = "Invalid username or password." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpPost("google/login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleUserLoginDTO googleLoginDTO)
        {
            try
            {
                var response = await authService.GoogleLoginAsync(googleLoginDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Google login failed.", details = ex.Message });
            }
        }

        [HttpPost("google/set-password")]
        public async Task<IActionResult> GoogleSetPassword([FromBody] SetPasswordDTO setPasswordDTO, [FromHeader(Name = "Authorization")] string authorizationHeader)
        {
            try
            {
                if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
                    return BadRequest(new { message = "Invalid authorization header." });

                var token = authorizationHeader.Substring("Bearer ".Length).Trim();
                var response = await authService.GoogleSetPasswordAsync(setPasswordDTO, token);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
                return Unauthorized(new { message = "You need to be logged in to logout." });

            try
            {
                var result = await authService.LogoutAsync(username);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request)
        {
            if (string.IsNullOrEmpty(request.CurrentPassword) ||
                string.IsNullOrEmpty(request.NewPassword) ||
                string.IsNullOrEmpty(request.ConfirmNewPassword))
            {
                return BadRequest(new { message = "All fields are required." });
            }

            try
            {
                var username = User.FindFirst(ClaimTypes.Name)?.Value;
                if (string.IsNullOrEmpty(username))
                    return Unauthorized(new { message = "User not found." });

                var result = await authService.ChangePasswordAsync(username, request);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokens([FromBody] RefreshTokenRequestDto request)
        {
            if (string.IsNullOrEmpty(request.UserId.ToString()) || string.IsNullOrEmpty(request.RefreshToken))
                return BadRequest(new { message = "UserId and RefreshToken cannot be empty." });

            try
            {
                var result = await authService.RefreshTokensAsync(request);
                if (result == null)
                    return Unauthorized(new { message = "Invalid refresh token." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpDelete("delete/{username}")]
        public async Task<IActionResult> SoftDeleteAccount(string username)
        {
            try
            {
                var result = await authService.SoftDeleteAccountAsync(username);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error while soft deleting account.", details = ex.Message });
            }
        }

        [HttpPut("restore/{username}")]
        public async Task<IActionResult> RestoreAccount(string username)
        {
            try
            {
                var result = await authService.RestoreAccountAsync(username);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error while restoring account.", details = ex.Message });
            }
        }

        [HttpPost("password/forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto request)
        {
            var result = await authService.ForgotPassword(request);
            return Ok(new { message = result });
        }

        [HttpPost("password/reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
        {
            var result = await authService.ResetPassword(request);
            return Ok(new { message = result });
        }
    }
}
