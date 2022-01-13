namespace AuthAPI.Services.Interfaces;

public interface ITokenValidatorService
{
    Task<bool> IsValid(string token);
    Task<string> GenerateJwt();
}