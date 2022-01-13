using MediatR;
using WebApp.TodoAPI.Domains.Inputs;

namespace WebApp.MediatorForTodoAPI.Command;

public record DoTodoCommand(TodoIdInput TodoIdInput) : IRequest<Todo.Todo>;