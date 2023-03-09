using DatabaseSynchronization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseSynchronizationServices();
builder.Services.AddMassTransitServices(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
