using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MinimalTodos.UseCases
{
    public static class TodoListEndpoints
    {
        public static IEndpointRouteBuilder AddTodoListEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/todoList", async (CreateTodoList.Request request, ISender sender, CancellationToken token) => await sender.Send(request, token))
                .WithName(nameof(CreateTodoList));

            builder.MapGet("/todoList/{id}", (Guid id, ISender sender, CancellationToken token) => sender.Send(new GetTodoList.Request { Id = id }, token))
                .WithName(nameof(GetTodoList));

            builder.MapGet("/todoList", async ([FromServices] ISender sender, CancellationToken token) => await sender.Send(new GetAllTodoLists.Request(), token))
            .WithName(nameof(GetAllTodoLists));

            builder.MapPost("/todoList/{id}/todo", async (Guid id, CreateTodo.Request request, ISender sender, CancellationToken token) => await sender.Send(new CreateTodo.Request { ListId = id, Text = request.Text }, token))
                .WithName(nameof(CreateTodo));

            builder.MapGet("/todo/{id}", async (Guid id, ISender sender, CancellationToken token) => await sender.Send(new GetTodo.Request { Id = id }, token))
                .WithName(nameof(GetTodo));

            return builder;
        }
    }


}
