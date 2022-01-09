namespace MinimalTodos.Domain
{
    public class TodoList
    {
        private readonly ICollection<Todo> _todos = new List<Todo>();

        public Guid Id { get; init; } = Guid.NewGuid(); 
        public string Title { get; set; } = String.Empty;
        public IReadOnlyCollection<Todo> Todos  => _todos.ToList();

        public void AddTodo(Todo todo) => _todos?.Add(todo);
        public void RemoveTodo(Todo todo)
        {
            if (_todos.Contains(todo))
            {
                _todos.Remove(todo);
            }
        }
    }
}
