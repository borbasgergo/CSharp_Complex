using WebApp.Todo.Domains.Outputs;
using WebApp.TodoAPI.Domains.Errors;

namespace WebApp.TodoAPI.Extensions;

public static class InternalServerErrorExtension
{
    public static ErrorResponse InternalServerErrorResponse(this ErrorResponse _)
    {
        var error = new Error("InternalError", "Internal Server Error!");

        return new(error);
    }
}