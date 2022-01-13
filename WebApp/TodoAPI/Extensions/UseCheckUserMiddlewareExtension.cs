using WebApp.TodoAPI.Middlewares;

namespace WebApp.TodoAPI.Extensions;

public static class UseCheckUserMiddlewareExtension
{
    public static IApplicationBuilder UseCheckUserMiddleware(this WebApplication application) 
        => application.UseMiddleware<CheckUserMiddleware>();
}