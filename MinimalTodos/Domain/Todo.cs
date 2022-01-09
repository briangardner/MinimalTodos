namespace MinimalTodos.Domain
{
    public class Todo
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string? Text { get; set; } = default;
    }
}
