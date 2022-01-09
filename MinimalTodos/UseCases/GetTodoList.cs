namespace MinimalTodos.UseCases
{
    public class GetTodoList
    {
        public record Request
        {
            public Guid Id { get; init; }
        }
    }
}
