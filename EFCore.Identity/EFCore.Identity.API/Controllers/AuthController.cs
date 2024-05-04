using EFCore.Identity.API.Dtos;
using EFCore.Identity.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto request, CancellationToken cancellationToken)
        {
            AppUser appUser = new AppUser()
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _userManager.FindByIdAsync(changePasswordDto.Id.ToString());

            if (appUser is null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            IdentityResult result = await _userManager.ChangePasswordAsync(appUser, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return NoContent(); 

        }

        [HttpGet]
        public async Task<IActionResult> ForgotPassword(string email, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(email);

            if (appUser is null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            return Ok(new {Token = token});
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordUsingToken(ChangePasswordUsingTokenDto request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(request.Email);

            if (appUser is null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(appUser, request.Token, request.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return NoContent();

        }
    }
}
