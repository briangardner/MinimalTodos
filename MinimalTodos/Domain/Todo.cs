namespace MinimalTodos.Domain
{
    public class Todo
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid ListId { get; init; }
        public string Text { get; set; } = string.Empty;
    }
}
