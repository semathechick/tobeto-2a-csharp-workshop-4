﻿using Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace Core.Utilities.Security.JWT
{
    public class JwtTokenHelper: ITokenHelper
    {
        private IConfiguration _configuration; //apsettings.dev.json
        private TokenOptions _tokenOptions;

        public JwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
            
        }
        public AccessToken CreateToken(User user)
        {
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_tokenOptions.ExpirationTime);
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                expires: expirationTime,
                signingCredentials: signingCredentials,
                notBefore: DateTime.UtcNow
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            string token = handler.WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                ExpirationTime = expirationTime,
            };
        }
    }
}