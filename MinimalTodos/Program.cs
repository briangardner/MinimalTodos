using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalTodos.Data;
using MinimalTodos.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.CustomSchemaIds(x => x.FullName);
});
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddDbContext<TodoDbContext>(options => options.UseInMemoryDatabase("items"));
var app = builder.Build();
app.Lifetime.ApplicationStopping.Register(() =>
{
    //remove in-memory database
    app.Services.GetService<TodoDbContext>()?.Database.EnsureDeleted();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.AddTodoListEndpoints();

app.Run();



