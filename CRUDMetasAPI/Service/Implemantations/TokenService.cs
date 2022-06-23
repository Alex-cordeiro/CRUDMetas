using Telemetrix.API.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Telemetrix.API.Service.Implemantations
{
    public class TokenService : ITokenService
    {
        private readonly TokenConfigurations _tokenConfigurations;

        public TokenService(TokenConfigurations tokenConfigurations)
        {
            _tokenConfigurations = tokenConfigurations;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfigurations.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: _tokenConfigurations.Issuer,
                audience: _tokenConfigurations.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_tokenConfigurations.Minutes),
                signingCredentials: signinCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfigurations.Secret)),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var  principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
                    !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCulture)) throw new SecurityTokenException("Token Inválido!!!");
            return principal;
        }
    }
}
