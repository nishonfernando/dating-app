using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        var tokenKey = configuration["TokenKey"] ?? throw new Exception("Cannot access token key from appsettings!");
        if (tokenKey.Length < 64) throw new Exception("Token key needs to be longer than 64 characters!");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

        if (user.UserName == null) throw new Exception("No username for user!");

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName)
        };

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
