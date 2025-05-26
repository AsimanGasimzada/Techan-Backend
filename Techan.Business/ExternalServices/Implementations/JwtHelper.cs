using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Techan.Business.ExternalServices.Abstractions;
using Techan.Business.Helpers.Encrypting;

namespace Techan.Business.ExternalServices.Implementations;
internal class JwtHelper : ITokenHelper
{
    private readonly IConfiguration _configuration;
    private readonly TokenOptionDto _tokenOptions;
    private readonly DateTime _expiresAt;
    public JwtHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptionDto>() ?? new();
        _expiresAt = DateTime.UtcNow.AddMinutes(_tokenOptions.TokenExpiration);
    }

    public AccessTokenDto CreateToken(List<Claim> claims)
    {
        JwtHeader jwtHeader = CreateJwtHeader();
        JwtPayload jwtPayload = CreateJwtPayload(claims);
        JwtSecurityToken jwtToken = new(jwtHeader, jwtPayload);

        return CreateAccessToken(jwtToken);

    }

    private AccessTokenDto CreateAccessToken(JwtSecurityToken jwtToken)
    {
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

        return new()
        {
            Token = jwtSecurityTokenHandler.WriteToken(jwtToken),
            ExpiredDate = _expiresAt,
            RefreshToken = GenerateRefreshToken(),
            RefreshTokenExpiredAt = _expiresAt.AddMinutes(15)
        };

    }

    private JwtPayload CreateJwtPayload(List<Claim> claims)
    {
        return new(
            issuer: _tokenOptions.Issuer,
            audience: _tokenOptions.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: _expiresAt
            );
    }

    private JwtHeader CreateJwtHeader()
    {
        SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        SigningCredentials signingCredentials = SigninCredentialsHelper.CreateSigninCredentials(securityKey);
        JwtHeader jwtHeader = new(signingCredentials);
        return jwtHeader;
    }

    private string GenerateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }
}
