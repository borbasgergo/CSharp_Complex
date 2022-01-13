using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Todo.Domains.Outputs;
using WebApp.TodoAPI.Exceptions;

namespace WebApp.TodoAPI.Filters;

public class BadRequestExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {

        CheckException(context);

    }

    
    private static void CheckException(ExceptionContext context)
    {

        if (context.Exception is BadRequestException exception)
        {
            var errorResponse = new ErrorResponse(exception);

            context.Result = new JsonResult(errorResponse)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            context.ExceptionHandled = true;
        }
        
    }
}