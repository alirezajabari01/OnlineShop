using Microsoft.IdentityModel.Tokens;
using OnlineShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Security
{
    public class TokenGenerator
    {
        public static string GenerateToken(ApplicationUser user)
        {
            var token = "";

            if (user != null)
            {
                var claims = new List<Claim>();

                claims.Add(new Claim("UserId", user.Id));
                foreach (var role in user.UserRoles)
                {
                    claims.Add(new Claim("role", role.Role.Name));
                    foreach (var roleClaim in role.Role.RoleClaims)
                    {
                        claims.Add(new Claim("roleClaim", roleClaim.ClaimValue));
                    }
                }

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
                    Issuer = user.UserName,
                    Expires = DateTime.UtcNow.AddHours(9),
                    Audience = user.UserName,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (Encoding.ASCII.GetBytes("in shabi@ke migan shab nist age shabe^mesle dishab nist")
                ), SecurityAlgorithms.HmacSha256Signature)
                };

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                token = tokenHandler.WriteToken(securityToken);
            }

            return token;
        }
        public static ClaimsPrincipal ValidateToken(string token)
        {
            var parameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes
                ("in shabi@ke migan shab nist age shabe^mesle dishab nist"))
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);
        }
    }
}
