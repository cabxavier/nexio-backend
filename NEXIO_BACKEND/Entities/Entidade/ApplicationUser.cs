using Microsoft.AspNetCore.Identity;

namespace Entities.Entidade
{
    public class ApplicationUser : IdentityUser
    {
        public string Cpf { get; set; }
    }
}
