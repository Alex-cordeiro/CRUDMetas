using Telemetrix.API.Configuration;
using Telemetrix.API.Context;
using Telemetrix.API.Model.DTOs;
using Telemetrix.API.Service.Implemantations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Telemetrix.API.Service
{
    public interface ILoginService
    {
        TokenDTO ValidarCredenciais(UsuarioDTO usuarioDTO);
        TokenDTO ValidarCredenciais(TokenDTO token);
    }
    public class LoginService : ILoginService
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfigurations _configurations;
        private readonly AutenticacaoService _autenticacaoService;
        private readonly TokenService _tokenService;
        private readonly MetasContext _metasContext;

        public LoginService(TokenConfigurations configurations, AutenticacaoService autenticacaoService, TokenService tokenService, MetasContext metasContext)
        {
            _configurations = configurations;
            _autenticacaoService = autenticacaoService;
            _tokenService = tokenService;
            _metasContext = metasContext;
        }

        public TokenDTO ValidarCredenciais(UsuarioDTO usuarioDTO)
        {
            var user = _autenticacaoService.ValidarCredenciais(usuarioDTO);
            if(user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configurations.DaysToExpiry);

            DateTime createDate = DateTime.Now;
            DateTime expirarionDate = createDate.AddMinutes(_configurations.Minutes);

            _autenticacaoService.AtualizarRefreshToken(usuarioDTO);

            return new TokenDTO(
                true, 
                createDate.ToString(DATE_FORMAT),
                expirarionDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken);
        }

        public TokenDTO ValidarCredenciais(TokenDTO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var username = principal.Identity.Name;

            var user = _autenticacaoService.ValidarCredenciais(username);

            if (user == null || user.RefreshToken != refreshToken
                || user.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _autenticacaoService.AtualizarRefreshToken(user);

            DateTime createDate = DateTime.Now;
            DateTime expirarionDate = createDate.AddMinutes(_configurations.Minutes);

            return new TokenDTO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirarionDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken);
        }
    }
}
