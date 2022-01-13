using MediatR;
using WebApp.MediatorForTodoAPI.Command;
using WebApp.MediatorForTodoAPI.DataAccess;

namespace WebApp.MediatorForTodoAPI.Handler;

public class InsertTodoHandler : IRequestHandler<InsertTodoCommand, Todo.Todo>
{
    private readonly ITodoDataAccess _todoDataAccess;

    public InsertTodoHandler(ITodoDataAccess todoDataAccess)
    {
        _todoDataAccess = todoDataAccess;
    }
    public Task<Todo.Todo> Handle(InsertTodoCommand request, CancellationToken cancellationToken)
    {
        return _todoDataAccess.Add(request.CreateTodoInput.What);
    }
}