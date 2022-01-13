namespace WebApp.MediatorForTodoAPI.DataAccess;

public interface ITodoDataAccess
{
    public Task<Todo.Todo> GetOneById(int id);
    public Task<bool> Delete(Todo.Todo todo);
    public Task<Todo.Todo> Add(string what);
    public Task<Todo.Todo> Do(Todo.Todo todo);
    public Task<List<Todo.Todo>> GetAll();
}