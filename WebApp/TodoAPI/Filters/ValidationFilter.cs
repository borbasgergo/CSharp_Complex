using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Todo.Domains.Outputs;
using WebApp.TodoAPI.Domains.Errors;

namespace WebApp.TodoAPI.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value!.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, 
                    kvp => kvp.Value!.Errors.Select(y => y.ErrorMessage))
                .ToArray();

            var response = new ErrorResponse();

            foreach (var error in errors)
            {
                foreach (var actualError in error.Value)
                {
                    var errorModel = new Error(
                        "ValidationError",
                        actualError);
                    
                    response.Errors.Add(errorModel);
                }
            }

            context.Result = new BadRequestObjectResult(response);
            return;
            
        }

        await next();
    }
}