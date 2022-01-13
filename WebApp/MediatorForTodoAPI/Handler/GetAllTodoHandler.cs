using MediatR;
using WebApp.MediatorForTodoAPI.DataAccess;
using WebApp.MediatorForTodoAPI.Query;

namespace WebApp.MediatorForTodoAPI.Handler;

public class GetAllTodoHandler : IRequestHandler<GetAllTodoQuery, List<Todo.Todo>>
{
    private readonly ITodoDataAccess _todoDataAccess;

    public GetAllTodoHandler(
        ITodoDataAccess todoDataAccess
        )
    {
        _todoDataAccess = todoDataAccess;
    }
    public Task<List<Todo.Todo>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
    {
        return _todoDataAccess.GetAll();
    }
}