using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> SignInManager;

        public UsersController(UserManager<ApplicationUser> UserManager, SignInManager<ApplicationUser> SignInManager)
        {
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
        }

        [AllowAnonymous]
        [HttpPost("/api/user/Create")]
        [Produces("application/json")]        
        public async Task<IActionResult> Create([FromBody] Login Login)
        {
            if (string.IsNullOrWhiteSpace(Login.Email))
            {
                return this.BadRequest("Informe o e-mail");
            }

            if (string.IsNullOrWhiteSpace(Login.Senha))
            {
                return this.BadRequest("Informe a senha");
            }

            if (string.IsNullOrWhiteSpace(Login.Cpf))
            {
                return this.BadRequest("Informe o cpf");
            }

            if (Login.Cpf.Length != 11)
            {
                return this.BadRequest("O tamanho do cpf é inválido");
            }

            var User = new ApplicationUser
            {
                Email = Login.Email,
                UserName = Login.Email,
                Cpf = Login.Cpf
            };

            var result = await this.UserManager.CreateAsync(User, Login.Senha);

            if (result.Errors.Any())
            {
                return this.BadRequest(result.Errors);
            }

            /// retorno do email
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(WebEncoders.Base64UrlEncode
                (Encoding.UTF8.GetBytes(await this.UserManager.GenerateEmailConfirmationTokenAsync(User)))));

            if ((await this.UserManager.ConfirmEmailAsync(User, code)).Succeeded)
            {
                return this.Ok("Usuário cadastrado com sucesso");
            }
            else
            {
                return this.BadRequest("Erro ao confirmar cadastro do usuário");
            }
        }
    }
}
