using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SWT.Services.AuthAPI.Models;
using SWT.Services.AuthAPI.Service.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SWT.Services.AuthAPI.Service
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;
        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions=jwtOptions.Value;
        }
        public string GenerateToken(ApplicationUser user)
        {
            string token = null;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

                var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Name),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Name,user.UserName)
            };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Audience = _jwtOptions.Audience,
                    Issuer = _jwtOptions.Issuer,
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokena = tokenHandler.CreateToken(tokenDescriptor);
                token= tokenHandler.WriteToken(tokena);
            }
            catch (Exception ex)
            {

            }
            return token;
        }
    }
}
