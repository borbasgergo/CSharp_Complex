namespace WebApp.Todo.Services;

[ObsoleteAttribute("Use mediator instead!")]
public interface ITodoService
{
    public Task<Todo?> CreateTodo(string what);
    public Task<Todo> GetTodo(int id);
    public Task<bool> DeleteTodo(int id);
    // public Task<bool> DoTodo(int id);
    public Task<List<Todo>> GetAllTodo();
}