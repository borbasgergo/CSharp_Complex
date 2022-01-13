using FluentValidation;
using WebApp.TodoAPI.Domains.Inputs;

namespace WebApp.TodoAPI.Validators;

public class TodoIdInputValidator : AbstractValidator<CreateTodoInput>
{
    public TodoIdInputValidator()
    {
        RuleFor(x => x.What)
            .NotEmpty();
    }
}