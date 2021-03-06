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
            private readonly TodoDbContext _dbContext;

            public Handler(TodoDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<IResult> Handle(Request request, CancellationToken cancellationToken)
            {
                var list = new TodoList()
                {
                    Title = request.Name
                };
                _dbContext.ToDoLists.Add(list);
                await _dbContext.SaveChangesAsync(cancellationToken);
                var response = new { id = list.Id };
                return Results.CreatedAtRoute(nameof(GetTodoList), response, response);

            }
        }
    }
    

}
