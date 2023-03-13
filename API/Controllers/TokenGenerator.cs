using API.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Principal;

namespace API.Controllers
{
    public class TokenGenerator
    {
        public static string GenerateToken(User user)
        {
            List<Claim> claims = new() { new Claim(ClaimTypes.Name, user.Name), new Claim(ClaimTypes.Role, user.Admin ? "admin":"user") };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Secret_KeyStringJWT"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
