using WebApp.Installers;
using WebApp.Todo.Extensions;
using WebApp.TodoAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Install services
builder.Services.AddServicesExtension();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }

app.UseCheckUserMiddleware();
app.UseExceptionHandlerExtension();
app.MapControllers();
app.Run();