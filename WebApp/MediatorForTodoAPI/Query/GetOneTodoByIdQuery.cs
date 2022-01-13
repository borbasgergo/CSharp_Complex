using MediatR;

namespace WebApp.MediatorForTodoAPI.Query;

public record GetOneTodoByIdQuery(int Id) : IRequest<Todo.Todo>;