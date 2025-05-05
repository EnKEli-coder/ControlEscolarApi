using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ControlEscolarApi.Application.Authentication.Common.Interfaces;
using ControlEscolarApi.Application.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ControlEscolarApi.Infrastructure.Authentication;

/// <summary>
/// Maneja la creación de jwt
/// </summary>
public class jwtTokenGenerator(
    IDateTimeProvider dateTimeProvider,
    IOptions<JwtSettings> jwtOptions) : IJwtTokenGenerator
{

    private readonly JwtSettings _jwtSettings = jwtOptions.Value;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    public string GenerarToken(int id, string username)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {   
            new Claim(JwtRegisteredClaimNames.Sub,id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("preferred_username", username)
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}