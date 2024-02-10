using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MyApi.Data.Model;

namespace MyApi.Util
{
    public class AuthConfig
    {
        private readonly IConfiguration _configuration;
        public AuthConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string GetToken(User user)
        {
            var claims = new[] 
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("Id", user.id.ToString()),
                new Claim("Username", user.Username),
                new Claim("Password", user.Password),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(3), signingCredentials: signIn
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}