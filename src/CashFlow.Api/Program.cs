using CashFlow.Api;
using CashFlow.Api.Filters;
using CashFlow.Infrastructure;
using CashFlow.Application;
using CashFlow.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateDatabase();

app.Run();

async Task MigrateDatabase()
{
    // Cria um escopo para ter acesso ao serviço de injeção de dependência
    await using var scope = app.Services.CreateAsyncScope();

    await DataBaseMigration.MigrateDatabase(scope.ServiceProvider);
}
