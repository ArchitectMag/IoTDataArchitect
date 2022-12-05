//System
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

//Project
using MyIoT.Core.Extensions;
using MyIoT.Core.Utilities.Security.Encryption;
using MyIoT.Core.Utilities.Security.UserEntity;

namespace MyIoT.Core.Utilities.Security.JWT;

public class JWTHelper : ITokenHelper
{
    public IConfiguration _configuration { get; }
    private TokenOptions _tokenOptions;
    DateTime _accesTokenExpiration;

    public JWTHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }

    public async Task<AccessToken> CreateToken(User user, List<Role> roles)
    {
        _accesTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.TokenExpire);
        var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, roles);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);

        return await Task.FromResult(new AccessToken
        {
            ExpireDate = _accesTokenExpiration,
            Token = token,
            RefreshToken = await CreateRefreshToken()
        });
    }

    public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<Role> roles)
    {
        return new JwtSecurityToken(
            issuer: _tokenOptions.Issuer,
            audience: _tokenOptions.Audience,
            expires: _accesTokenExpiration,
            notBefore: DateTime.Now,
            claims: SetClaims(user, roles),
            signingCredentials: signingCredentials
            );
    }

    public async Task<string> CreateRefreshToken()
    {
        byte[] number = new byte[32];
        using (RandomNumberGenerator random = RandomNumberGenerator.Create())
        {
            random.GetBytes(number);
            return await Task.FromResult(Convert.ToBase64String(number));
        }
    }

    private IEnumerable<Claim> SetClaims(User user, List<Role> roles)
    {
        var claims = new List<Claim>();
        claims.AddEmail(user.Email);
        claims.AddName($"{user.FistName} {user.LastName}");
        claims.AddNameIdentifier(user.Id.ToString());
        claims.AddRoles(roles.Select(r => r.Name).ToArray());
        return claims;
    }
}
