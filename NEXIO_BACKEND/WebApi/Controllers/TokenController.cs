using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Token;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> SignInManager;

        public TokenController(UserManager<ApplicationUser> UserManager, SignInManager<ApplicationUser> SignInManager)
        {
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
        }

        [AllowAnonymous]        
        [HttpPost("/api/token/Create")]
        [Produces("application/json")]
        public async Task<ActionResult> Create([FromBody] Modelnput ModelInput)
        {
            if (string.IsNullOrWhiteSpace(ModelInput.Email))
            {
                return this.BadRequest("Informe o e-mail");
            }

            if (string.IsNullOrWhiteSpace(ModelInput.Password))
            {
                return this.BadRequest("Informe a senha");
            }

            if ((await this.SignInManager.PasswordSignInAsync(ModelInput.Email, ModelInput.Password, false, lockoutOnFailure: false)).Succeeded)
            {
                var token = new JwtTokenBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("S3cr3t@K3y-971$5247"))
                    .AddSubject("Nexio Tecnologia")
                    .AddIssuer("Nexio.Securiry.Bearer")
                    .AddAudience("Nexio.Securiry.Bearer")
                    .AddClaim("NexioAPI", "1")
                    .AddExpiry(20)
                    .Builder();

                return this.Ok(token.Value);

            }
            else
            {
                return this.Unauthorized("E-mail e/ou senha inválidos");
            }

        }
    }
}
