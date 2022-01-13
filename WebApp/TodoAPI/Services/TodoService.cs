using WebApp.MediatorForTodoAPI.DataAccess;
using WebApp.Todo.Services;

namespace WebApp.TodoAPI.Services;


[ObsoleteAttribute("Use mediator instead!")]

public class TodoService : ITodoService
{

    private readonly ITodoDataAccess _todoDataAccess;
    
    public TodoService(ITodoDataAccess todoDataAccess)
    {
        _todoDataAccess = todoDataAccess;
    }
    
    public async Task<Todo.Todo?> CreateTodo(string what) => await _todoDataAccess.Add(what);

    public async Task<Todo.Todo> GetTodo(int id) => await _todoDataAccess.GetOneById(id);

    public async Task<bool> DeleteTodo(int id)
    {
        var todo = await GetTodo(id);
        
        return await _todoDataAccess.Delete(todo);
    }


    /* public async Task<bool> DoTodo(int id)
    {
        var todo = await GetTodo(id);
        
        return await _todoDataAccess.Do(todo);
        
    } */

    public async Task<List<Todo.Todo>> GetAllTodo() => await _todoDataAccess.GetAll();
} 