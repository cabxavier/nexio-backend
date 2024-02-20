using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Token
{
    public class JwtToken
    {
        private JwtSecurityToken Token;

        public JwtToken(JwtSecurityToken Token)
        {
            this.Token = Token;
        }

        public DateTime ValidTo => this.Token.ValidTo;

        public string Value => new JwtSecurityTokenHandler().WriteToken(this.Token);
    }
}
