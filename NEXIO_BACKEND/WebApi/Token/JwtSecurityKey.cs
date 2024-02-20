using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Token
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string Secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
