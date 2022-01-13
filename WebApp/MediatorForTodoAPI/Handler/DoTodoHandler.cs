using MediatR;
using WebApp.MediatorForTodoAPI.Command;
using WebApp.MediatorForTodoAPI.DataAccess;
using WebApp.MediatorForTodoAPI.Query;

namespace WebApp.MediatorForTodoAPI.Handler;

public class DoTodoHandler : IRequestHandler<DoTodoCommand, Todo.Todo>
{
    private readonly IMediator _mediator;
    private readonly ITodoDataAccess _todoDataAccess;
    public DoTodoHandler(IMediator mediator, ITodoDataAccess todoDataAccess)
    {
        _mediator = mediator;
        _todoDataAccess = todoDataAccess;
    }
    public async Task<Todo.Todo> Handle(DoTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _mediator.Send(new GetOneTodoByIdQuery(request.TodoIdInput.Id), cancellationToken);

        var result = await _todoDataAccess.Do(todo);

        return result;
    }
}