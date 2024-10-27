using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthApi.Data;
using DTOs.Auth.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AuthApi.Helper;

public class AuthServiceHelper
{
    private readonly IConfiguration _configuration;
    public AuthServiceHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public JwtSecurityToken GenerateToken(AuthUserModel User)
    {
        var JWT_SECRET = _configuration.GetSection("JWT:SECRET").Value ?? string.Empty;
        var EXPIRATION_TIME = _configuration.GetSection("JWT:EXPIRATION_TIME").Value ?? "30";

        if (!int.TryParse(EXPIRATION_TIME, out int expirationMinutes))
        {
            expirationMinutes = 30; 
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_SECRET));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var claims = new List<Claim>
        {
                new Claim(ClaimTypes.Name, User.UserName),
                new Claim(ClaimTypes.Email, User.Email),
        };

        var token = new JwtSecurityToken(
            issuer: "https://localhost:3001",
            audience: "https://localhost:3001",
            claims: claims,
            expires: DateTime.Now.AddMinutes(expirationMinutes),
            signingCredentials: creds);

        return token;
    }
}