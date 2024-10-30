using Apollo.Auth.Api.Services.TokenCtx.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace Apollo.Auth.Api.Services.TokenCtx;

public class TokenService(IConfiguration configuration) : ITokenService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly DateTime _horarioBrasilia = DateTime.UtcNow.AddHours(-3);

    public string GenerateToken(string id)
    {
        var secret = _configuration.GetSection("Secret").Value;

        JwtSecurityTokenHandler tokenHandler = new();
        byte[] key = Encoding.ASCII.GetBytes(secret);
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity([
                new Claim("sub", id),
                ]),

            Expires = _horarioBrasilia.AddMinutes(90),
            NotBefore = _horarioBrasilia,
            Issuer = "Apollo Auth API",
            Audience = "Apollo Web",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
