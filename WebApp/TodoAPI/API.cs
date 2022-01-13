using System.Runtime.Serialization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.MediatorForTodoAPI.Command;
using WebApp.MediatorForTodoAPI.Query;
using WebApp.TodoAPI.Domains.Inputs;
using WebApp.TodoAPI.Filters.AttributeFilters;

namespace WebApp.TodoAPI;

[ApiController]
[Route("/api/todo/v1/")]
public class Api
{
    
    private readonly IMediator _mediator;

    public Api(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AuthNotRequired]
    public async Task<IActionResult> GetAllTodos()
    {
        var todos = await _mediator.Send(new GetAllTodoQuery());

        return new JsonResult(todos)
        {
            StatusCode = StatusCodes.Status200OK
        };
    }

    [HttpGet("{id}")]
    [AuthRequired]
    public async Task<IActionResult> GetOneTodoById(int id)
    {
        var todo = await _mediator.Send(new GetOneTodoByIdQuery(id));
        
        return new JsonResult(todo)
        {
            StatusCode = StatusCodes.Status200OK
        };
    }

    [HttpPost("save")]
    [AuthRequired]
    public async Task<IActionResult> SaveTodo([FromBody] CreateTodoInput todoInput)
    {
        
        var todo = await _mediator.Send(new InsertTodoCommand(todoInput));

        return new JsonResult(todo)
        {
            StatusCode = StatusCodes.Status201Created
        };

    }

    [HttpPut("delete")]
    [AuthRequired]
    public async Task<IActionResult> Delete([FromForm] TodoIdInput deleteTodoInput)
    {
        await _mediator.Send(new DeleteTodoCommand(deleteTodoInput.Id));

        return new OkResult();
    }
    

    [HttpPost("do")]
    [AuthRequired]
    public async Task<IActionResult> Do([FromForm] TodoIdInput doTodoIdInput)
    {
        var todo = await _mediator.Send(new DoTodoCommand(doTodoIdInput));

        return new OkObjectResult(todo);

    }
}
