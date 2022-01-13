using FluentValidation.AspNetCore;
using MediatR;
using WebApp.MediatorForTodoAPI.DataAccess;
using WebApp.TodoAPI;
using WebApp.TodoAPI.Filters;

namespace WebApp.Installers;

public static class ServiceInstallerExtension
{
    public static IServiceCollection AddServicesExtension(
            this IServiceCollection service
        )
    {

        service.AddFluentValidation(
            options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Program>();
            }
        );
        
        service.AddScoped<ITodoDataAccess, TodoDataAccess>();
        service.AddDbContext<TodoDbContext>();
        service.AddMediatR(typeof(Program).Assembly);
        
        service.AddControllers(
            options =>
                {
                    options.Filters.Add<BadRequestExceptionFilter>();
                    options.Filters.Add<ValidationFilter>();
            
                }
            ).ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                }
            );
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // service.AddEndpointsApiExplorer();
        
        return service;
    }
}