using WebApp.TodoAPI.Domains.Errors;
using WebApp.TodoAPI.Exceptions;

namespace WebApp.Todo.Domains.Outputs;

public class ErrorResponse
{

    public List<Error> Errors { get; } = new();
    
    public bool IsError { get; init; } = true;

    public ErrorResponse() { }

    public ErrorResponse(Error error)
    {
        Errors.Add(error);
    }
    public ErrorResponse(BadRequestException exception)
    {
        var error = new Error(exception.Error.ErrorCode, exception.Error.ErrorMessage);
        
        Errors.Add(error);
    }
}