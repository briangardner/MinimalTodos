using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalTodos.Data;
using MinimalTodos.Domain;

namespace MinimalTodos.UseCases
{
    public class GetTodoList
    {
        public record Request : IRequest<IResult>
        {
            public Guid Id { get; init; }
        }

        public class Handler : IRequestHandler<Request, IResult>
        {
            private readonly TodoDbContext _context;

            public Handler(TodoDbContext context)
            {
                _context = context;
            }
            public async Task<IResult> Handle(Request request, CancellationToken cancellationToken)
            {
                var record = await _context.ToDoLists
                    .Include(x => x.Todos )
                    .FirstOrDefaultAsync( x=> x.Id == request.Id, cancellationToken );
                return record is not null ?
                    Results.Ok(record) :  Results.NotFound();
            }
        }
    }
}
