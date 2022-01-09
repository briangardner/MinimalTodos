using MediatR;
using MinimalTodos.Data;
using MinimalTodos.Domain;

namespace MinimalTodos.UseCases
{
    public class CreateTodoList
    {
        public record Request : IRequest<IResult>
        {
            public string Name { get; init; } = string.Empty;
        }

        public class Handler : IRequestHandler<Request, IResult>
        {
            private readonly TodoDbContext dbContext;

            public Handler(TodoDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IResult> Handle(Request request, CancellationToken cancellationToken)
            {
                var list = new TodoList()
                {
                    Title = request.Name
                };
                dbContext.ToDoLists.Add(list);
                await dbContext.SaveChangesAsync(cancellationToken);
                var response = new { id = list.Id };
                return Results.CreatedAtRoute(nameof(GetTodoList), response, response);

            }
        }
    }
    

}
