// TokenService.cs
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public interface ITokenService
{
    string GenerateToken(string userId);
}

public class TokenService : ITokenService
{
    public string GenerateToken(string userId)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thmpv-77d6f-94376-8hgkg-vrdrq"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "boleto-api",
            audience: "boleto-audience",
            claims: new[] { new Claim(ClaimTypes.NameIdentifier, userId) },
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
