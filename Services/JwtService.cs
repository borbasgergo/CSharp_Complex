using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthAPI.Domains.Inputs;
using AuthAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace AuthAPI.Services;

public class JwtService : IJwtService
{
    private readonly ITokenValidatorService _tokenValidatorService;

    public JwtService(ITokenValidatorService tokenValidatorService)
    {
        _tokenValidatorService = tokenValidatorService;
    }

    public async Task<bool> IsValidJwt(JwtHeaderInput jwtModel) 
        => await _tokenValidatorService.IsValid(jwtModel.Jwt);

    public async Task<string> CreateToken() 
        => await _tokenValidatorService.GenerateJwt();
    
}