using CustomerCommand.API.Extensions;
using CustomerCommands.Application;
using CustomerCommands.Infrastructure;
using CustomerCommands.Infrastructure.Persistence;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MigrateDatabase<BooksAndVideosContext>((context, services) =>
    {
        BooksAndVideosContextSeed
            .SeedAsync(context)
            .Wait();
    });

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
