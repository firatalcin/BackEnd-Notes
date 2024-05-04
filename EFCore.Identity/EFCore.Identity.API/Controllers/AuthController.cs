using EFCore.Identity.API.Dtos;
using EFCore.Identity.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _userManager.Users.FirstOrDefaultAsync(p => p.Email == request.UserNameOrEmail || p.UserName == request.UserNameOrEmail, cancellationToken);

            if (appUser is null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            bool result = await _userManager.CheckPasswordAsync(appUser, request.Password);

            if (!result)
            {
                return BadRequest(new { Message = "Şifre Yanlış"});
            }

            return Ok(new { Token = "Token" });

        }

        [HttpPost]
        public async Task<IActionResult> LoginWithSignInManager(LoginDto request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _userManager.Users.FirstOrDefaultAsync(p => p.Email == request.UserNameOrEmail || p.UserName == request.UserNameOrEmail, cancellationToken);

            if (appUser is null)
            {
                return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, request.Password, true);

            if (result.IsLockedOut)
            {
                TimeSpan? timeSpan =  appUser.LockoutEnd - DateTime.Now;

                if(timeSpan is not null)
                {
                    return StatusCode(500, $"Şifrenizi 3 kere yanlış girdiğiniz için kullanıcınız {timeSpan.Value.TotalSeconds} saniye girişi yasaklanmıştır. Süre bitiminde tekrar giriş yapabilirsiniz.");
                }
                else
                {
                    return StatusCode(500, $"Şifrenizi 3 kere yanlış girdiğiniz için kullanıcınız 30 saniye girişi yasaklanmıştır. Süre bitiminde tekrar giriş yapabilirsiniz.");
                }
            }

            if (!result.Succeeded)
            {
                return StatusCode(500, "Şifreniz Yanlış");
            }

            if (result.IsNotAllowed)
            {
                return StatusCode(500, "Mail adresiniz onaylı değil");
            }

           

            return Ok(new { Token = "Token" });

        }
    }
}
