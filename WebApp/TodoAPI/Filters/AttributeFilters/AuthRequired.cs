using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.TodoAPI.Domains.Errors;
using WebApp.TodoAPI.Exceptions;

namespace WebApp.TodoAPI.Filters.AttributeFilters;

public class AuthRequired: ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var auth = (bool) context.HttpContext.Items["Authenticated"]!;

        if (auth)
        {
            await next();
        }
        else
        {
            throw new BadRequestException(Errors.NotAuthenticated);
        }
        
    }
}