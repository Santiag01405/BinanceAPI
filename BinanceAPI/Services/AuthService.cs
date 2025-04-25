using BinanceAPI.Configurations;
using BinanceAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BinanceAPI.Services;

public class AuthService
{
    private readonly JwtSettings _jwtSettings;

    public AuthService(IConfiguration configuration)
    {
        _jwtSettings = new JwtSettings
        {
            SecretKey = configuration["Jwt:SecretKey"] ?? throw new Exception("Jwt:SecretKey missing"),
            Issuer = configuration["Jwt:Issuer"] ?? throw new Exception("Jwt:Issuer missing"),
            Audience = configuration["Jwt:Audience"] ?? throw new Exception("Jwt:Audience missing"),
            ExpiryMinutes = int.Parse(configuration["Jwt:ExpiryMinutes"] ?? "60")
        };
    }

    public LoginResponse Authenticate(string email, string password)
    {
        if (email != "admin@example.com" || password != "123456")
            throw new UnauthorizedAccessException("Invalid credentials");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Role, "User")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: creds);

        return new LoginResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };
    }
}
