using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApi.Token
{
    public class JwtTokenBuilder
    {
        private SecurityKey SecurityKey = null;
        private string Subject = "";
        private string Issuer = "";
        private string Audience = "";
        private Dictionary<string, string> Claims = new Dictionary<string, string>();
        private int ExpiryInMinutes = 30;


        public JwtTokenBuilder AddSecurityKey(SecurityKey SecurityKey)
        {
            this.SecurityKey = SecurityKey;
            return this;
        }

        public JwtTokenBuilder AddSubject(string Subject)
        {
            this.Subject = Subject;
            return this;
        }

        public JwtTokenBuilder AddIssuer(string Issuer)
        {
            this.Issuer = Issuer;
            return this;
        }

        public JwtTokenBuilder AddAudience(string Audience)
        {
            this.Audience = Audience;
            return this;
        }

        public JwtTokenBuilder AddClaim(string Type, string Value)
        {
            this.Claims.Add(Type, Value);
            return this;
        }

        public JwtTokenBuilder AddClaims(Dictionary<string, string> Claims)
        {
            this.Claims.Union(Claims);
            return this;
        }

        public JwtTokenBuilder AddExpiry(int ExpiryInMinutes)
        {
            this.ExpiryInMinutes = ExpiryInMinutes;
            return this;
        }


        private void EnsureArguments()
        {
            if (this.SecurityKey == null)
                throw new ArgumentNullException("Security Key");

            if (string.IsNullOrWhiteSpace(this.Subject))
                throw new ArgumentNullException("Subject");

            if (string.IsNullOrWhiteSpace(this.Issuer))
                throw new ArgumentNullException("Issuer");

            if (string.IsNullOrWhiteSpace(this.Audience))
                throw new ArgumentNullException("Audience");
        }

        public JwtToken Builder()
        {
            EnsureArguments();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,this.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(this.Claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
                issuer: this.Issuer,
                audience: this.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(ExpiryInMinutes),
                signingCredentials: new SigningCredentials(
                                                   this.SecurityKey,
                                                   SecurityAlgorithms.HmacSha256)

                );

            return new JwtToken(token);

        }
    }
}
