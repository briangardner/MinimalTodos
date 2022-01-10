namespace MinimalTodos.Domain
{
    public class TodoList
    {
        private readonly HashSet<Todo> _todos = new HashSet<Todo>();

        public Guid Id { get; init; } = Guid.NewGuid();
        public string Title { get; set; } = String.Empty;
        public IReadOnlyCollection<Todo> Todos => _todos.ToList();

        public Todo AddTodo(Todo todo) { _todos?.Add(todo); return todo;  }
        public void RemoveTodo(Todo todo)
        {
            if (_todos.Contains(todo))
            {
                _todos.Remove(todo);
            }
        }
    }
}
