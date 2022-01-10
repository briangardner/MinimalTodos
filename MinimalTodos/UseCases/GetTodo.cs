using MediatR;
using MinimalTodos.Data;
using MinimalTodos.Domain;

namespace MinimalTodos.UseCases
{
    public class GetTodo
    {
        public record Request : IRequest<IResult>
        {
            public Guid Id { get; init; }
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
                var todo = await _context.FindAsync<Todo>(request.Id);
                return todo is not null ?
                    Results.Ok(todo) :
                    Results.NotFound();
            }
        }
    }
}
