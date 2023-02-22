using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HelpMeApp.Services.Services
{
    public class TokenService : ITokenService
    {
        private const string UserIdClaim = "UserId";

        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(AppUser user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private List<Claim> GetClaims(AppUser user)
        {
            return new List<Claim> { new Claim(UserIdClaim, user.Id.ToString()), new Claim(ClaimTypes.Email, user.Email) };
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Key"]);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256Signature);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentialss, List<Claim> claims)
        {
            var jwtConfig = _configuration.GetSection("jwtConfig");

            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtConfig["Issuer"],
            audience: jwtConfig["Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(Convert.ToDouble(jwtConfig["expiresIn"])),
            signingCredentials: signingCredentialss
            );

            return tokenOptions;
        }
    }
}
