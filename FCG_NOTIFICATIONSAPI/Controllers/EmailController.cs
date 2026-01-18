using FCG_NOTIFICATIONSAPI.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG_NOTIFICATIONSAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> WelcomeEmail(string email)
        {
            await _emailService.SendAsync(
                  email,
                  "FCG - Boas Vindas",
                  "<h3>Seu cadastro foi realizado com sucesso!!!</h3>"
              );
            return Ok("Email enviado com sucesso");
        }
    }
}
