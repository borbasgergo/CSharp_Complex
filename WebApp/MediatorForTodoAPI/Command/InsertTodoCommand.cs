using MediatR;
using WebApp.TodoAPI.Domains.Inputs;

namespace WebApp.MediatorForTodoAPI.Command;

public record InsertTodoCommand(CreateTodoInput CreateTodoInput) : IRequest<Todo.Todo>;