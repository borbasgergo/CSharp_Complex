using Microsoft.EntityFrameworkCore;

namespace WebApp.TodoAPI;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options): 
        base(options) {}
    
    public DbSet<Todo.Todo> Todos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Username=;Password=;Database=postgres;");
    }
}