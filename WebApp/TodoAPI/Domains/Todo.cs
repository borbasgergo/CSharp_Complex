using WebApp.Todo.Builders;

namespace WebApp.Todo;

public class Todo
{
    public int Id { get; set; }
    public string What { get; set; }

    public bool IsDone { get; set; }

    public Todo(){}
    public Todo(TodoBuilder todoBuilder)
    {
        What = todoBuilder.What;
        
    }

    public static TodoBuilder Builder() => new();

}
