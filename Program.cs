using AuthAPI.Installers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddServices();

var app = builder.Build();

app.MapControllers();
app.Run();