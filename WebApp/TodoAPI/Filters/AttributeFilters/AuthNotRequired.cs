using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.TodoAPI.Filters.AttributeFilters;

public class AuthNotRequired : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(
        ActionExecutingContext _, ActionExecutionDelegate next
    ) => await next();
}