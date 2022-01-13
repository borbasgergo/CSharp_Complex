using MediatR;

namespace WebApp.MediatorForTodoAPI.Query;

public record GetAllTodoQuery() : IRequest<List<Todo.Todo>>;