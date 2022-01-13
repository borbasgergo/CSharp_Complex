using AuthAPI.Domains.Inputs;

namespace AuthAPI.Services.Interfaces;

public interface IJwtService
{
    Task<bool> IsValidJwt(JwtHeaderInput jwtModel);
    Task<string> CreateToken();
}