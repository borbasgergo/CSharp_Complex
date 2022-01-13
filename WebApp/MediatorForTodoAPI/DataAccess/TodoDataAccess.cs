using Microsoft.EntityFrameworkCore;
using WebApp.Todo;
using WebApp.TodoAPI;
using WebApp.TodoAPI.Domains.Errors;
using WebApp.TodoAPI.Exceptions;

namespace WebApp.MediatorForTodoAPI.DataAccess;


public class TodoDataAccess : ITodoDataAccess
{
    private readonly TodoDbContext _todoDbContext;

    public TodoDataAccess(
        TodoDbContext todoDbContext
        )
    {
        _todoDbContext = todoDbContext;
    }
    
    public async Task<Todo.Todo> GetOneById(int id)
    {
        var todo = await _todoDbContext.Todos.FindAsync(id)
                   ?? throw new BadRequestException(Errors.NotFound);
        
        return todo;
    }

    public async Task<Todo.Todo> Add(string what)
    {
        
        var todo = Todo.Todo.Builder()
                        .SetWhat(what)
                        .Build();
        try
        {
            var todoEntityEntry = await _todoDbContext.Todos.AddAsync(todo);

            await _todoDbContext.SaveChangesAsync();

            return todoEntityEntry.Entity;
        }
        catch (Exception _)
        {
            // Simple exception is going to be caught and turned into a internal server exception
            throw new Exception();
        }

    }

    public async Task<Todo.Todo> Do(Todo.Todo todo)
    {
        try
        {
            todo.IsDone = !todo.IsDone; 
        
            await _todoDbContext.SaveChangesAsync();

            return todo;
        }
        catch (Exception _)
        {
            throw new Exception();
        }

    }

    public async Task<List<Todo.Todo>> GetAll() => await _todoDbContext.Todos.ToListAsync();
    
    public async Task<bool> Delete(Todo.Todo todo)
    {

        _todoDbContext.Todos.Remove(todo);

        try
        {
            await _todoDbContext.SaveChangesAsync();
            
            return true;
        }
        catch (Exception _)
        {
            throw new BadRequestException(Errors.NotDeleted);
        }

        

    }
}