using System.Security.Claims;
using WebApp.TodoAPI.Domains.Errors;
using WebApp.TodoAPI.Exceptions;
using WebApp.TodoAPI.Helpers;

namespace WebApp.TodoAPI.Middlewares;

public class CheckUserMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    private readonly ILogger<CheckUserMiddleware> _logger;

    public CheckUserMiddleware(
        RequestDelegate requestDelegate,
        ILogger<CheckUserMiddleware> logger)
    {
        _requestDelegate = requestDelegate;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var result = false;
        
        try
        {
            result = await ValidateTokenWithAuthApi.ValidateJwtToken(context);

            _logger.LogInformation("Result: {0}", result);
            
        }
        finally
        {
            const string authenticated = "Authenticated";
        
            context.Items.Add(authenticated, result);
            
            await _requestDelegate.Invoke(context);
        }
        
    }
}