using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalTodos.Data;
using System.Text.Json.Serialization;

namespace MinimalTodos.UseCases
{
    public class CreateTodo
    {
        public record Request : IRequest<IResult>
        {
            [JsonIgnore]
            public Guid ListId { get; init; }
            public string Text { get; init; } = string.Empty;

        }

        public class Handler : IRequestHandler<Request, IResult>
        {
            private readonly TodoDbContext _context;

            public Handler(TodoDbContext dbContext)
            {
                _context = dbContext;
            }
            public async Task<IResult> Handle(Request request, CancellationToken cancellationToken)
            {
                var list = await _context.ToDoLists.FirstOrDefaultAsync(x => x.Id == request.ListId, cancellationToken);
                if (list == null)
                    return Results.NotFound();

                var todo = list.AddTodo(new Domain.Todo { Text = request.Text });
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync(cancellationToken);
                var response = new
                {
                    id = todo.Id
                };
                return Results.CreatedAtRoute(nameof(GetTodo), response, response);
            }
        }
    }
}
