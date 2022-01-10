using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalTodos.Domain;

namespace MinimalTodos.Data.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.HasMany(x => x.Todos)
                .WithOne()
                .HasForeignKey(x => x.ListId);

            builder.Metadata
                .FindNavigation(nameof(TodoList.Todos))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
