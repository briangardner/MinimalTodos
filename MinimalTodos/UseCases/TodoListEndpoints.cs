using MediatR;

namespace MinimalTodos.UseCases
{
    public static class TodoListEndpoints
    {
        public static IEndpointRouteBuilder AddTodoListEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/todoList", Dispatcher.Request<CreateTodoList.Request>).WithName(nameof(CreateTodoList));
            return builder;
        }
    }

    public static class Dispatcher
    {
        public static Task<IResult> Request<TRequest>(TRequest request, ISender mediator, CancellationToken cancellationToken)
        where TRequest : IRequest<IResult>
            => mediator.Send(request, cancellationToken);
    }

}
