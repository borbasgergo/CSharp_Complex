using System.Text.Json;
using WebApp.Todo.Domains.Outputs;
using WebApp.TodoAPI.Extensions;

namespace WebApp.Todo.Extensions;

public static class UseExceptionHandlerExt
{
    public static void UseExceptionHandlerExtension(
        this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseExceptionHandler(app =>
            app.Run(async context =>
            {
                var errorResponse = new ErrorResponse().InternalServerErrorResponse();

                var jsonObject = JsonSerializer.Serialize(errorResponse);

                context.Response.ContentType = "application/json";
                
                await context.Response.WriteAsync(jsonObject);

            }));
    }
}