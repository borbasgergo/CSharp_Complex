using MediatR;
using WebApp.MediatorForTodoAPI.DataAccess;
using WebApp.MediatorForTodoAPI.Query;

namespace WebApp.MediatorForTodoAPI.Handler;

public class GetOneTodoByIdHandler : IRequestHandler<GetOneTodoByIdQuery, Todo.Todo>
{

    private readonly ITodoDataAccess _todoDataAccess;
    public GetOneTodoByIdHandler(
        ITodoDataAccess todoDataAccess
        )
    {
        _todoDataAccess = todoDataAccess;
    }
    
    
    public Task<Todo.Todo> Handle(GetOneTodoByIdQuery request, CancellationToken cancellationToken)
    {
        return _todoDataAccess.GetOneById(request.Id);
    }
}