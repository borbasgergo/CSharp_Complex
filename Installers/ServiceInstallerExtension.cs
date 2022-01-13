using AuthAPI.Services;
using AuthAPI.Services.Interfaces;

namespace AuthAPI.Installers;

public static class ServiceInstallerExtension
{
    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddControllers();
        
        service.AddScoped<IJwtService, JwtService>();
        service.AddScoped<ITokenValidatorService, TokenValidatorService>();

        return service;
    }
}