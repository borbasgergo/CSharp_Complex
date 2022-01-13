namespace WebApp.Todo.Builders;

public class TodoBuilder
{
    public int Id { get; private set; }
    public string What { get; private set; }

    public bool IsDone { get; private set;  }

    
    public TodoBuilder SetIsDone(bool isDone)
    {
        IsDone = isDone;
        return this;
    }

    public TodoBuilder SetId(int id)
    {
        Id = id;
        return this;
    }
    
    public TodoBuilder SetWhat(string what)
    {
        What = what;
        return this;
    }

    public Todo Build()
    {
        Todo todo = new(this);
        return todo;
    }
}