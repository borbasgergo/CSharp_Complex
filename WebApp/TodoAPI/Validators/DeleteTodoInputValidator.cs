using FluentValidation;
using WebApp.TodoAPI.Domains.Inputs;

namespace WebApp.TodoAPI.Validators;

public class DeleteTodoInputValidator: AbstractValidator<TodoIdInput>
{
    public DeleteTodoInputValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
        
    }
}