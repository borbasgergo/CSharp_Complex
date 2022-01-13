using MediatR;

namespace WebApp.MediatorForTodoAPI.Command;

public record DeleteTodoCommand(int Id) : IRequest<bool>;