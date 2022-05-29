using FDNS.Common.Configuration;
using FDNS.Common.DataTransferObjects;
using FDNS.Services.Abstractions.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FDNS.Services.Security
{
    public class TokenService : ITokenService
    {
        private readonly JWTConfiguration _config;

        public TokenService(IOptions<JWTConfiguration> options)
        {
            _config = options.Value;
        }

        public string GenerateToken(UserDTO user, string? role = null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            if (role != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_config.ExpirationMinutes), 
                SigningCredentials = creds,
                Issuer = _config.Issuer
            };
            var token = new JsonWebTokenHandler().CreateToken(tokenDescriptor);

            return token;
        }
    }
}