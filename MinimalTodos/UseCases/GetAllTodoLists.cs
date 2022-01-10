using MediatR;
using MinimalTodos.Data;

namespace MinimalTodos.UseCases
{
    public class GetAllTodoLists
    {
        public record Request : IRequest<IResult>
        {

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
                return Results.Ok(_dbContext.ToDoLists.ToList());
            }
        }
    }
}
