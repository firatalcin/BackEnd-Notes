using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Record.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("[action]")]
        public IActionResult Login(LoginDto loginDto)
        {
            loginDto.Email = "firatalcin@gmail.com";
            return Ok("Giriş Başarılı");
        }

        [HttpPost("[action]")]
        public IActionResult LoginWithRecord(LoginDto loginDto)
        {
            //Record'da sonradan atama işlemi yapılamaz.
            //Login login2 = new("firatalcin@gmail.com", "1");
            return Ok("Giriş Başarılı");
        }
    }
}
