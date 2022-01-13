using MediatR;
using WebApp.MediatorForTodoAPI.Command;
using WebApp.MediatorForTodoAPI.DataAccess;

namespace WebApp.MediatorForTodoAPI.Handler;

public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, bool>
{

    private readonly ITodoDataAccess _todoDataAccess;

    public DeleteTodoHandler(ITodoDataAccess todoDataAccess)
    {
        _todoDataAccess = todoDataAccess;
    }
    
    public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _todoDataAccess.GetOneById(request.Id);
        
        return _todoDataAccess.Delete(todo).Result;
    }
}