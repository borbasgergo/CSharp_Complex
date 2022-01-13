using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace AuthAPI.Services;

public class TokenValidatorService : ITokenValidatorService
{
    private readonly IConfiguration _configuration;
    
    public TokenValidatorService(
        ILogger<TokenValidatorService> logger,
        IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public Task<bool> IsValid(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt-secret"]);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time
                ClockSkew = TimeSpan.Zero
            }, out _); 
        }
        catch (Exception _)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }
    public Task<string> GenerateJwt()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var secret = Encoding.ASCII.GetBytes(_configuration["Jwt-secret"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {new Claim("id", 1.ToString())}),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(secret), 
                    SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}