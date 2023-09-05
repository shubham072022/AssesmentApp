using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.Metrics;
using Todo.Domain.Entities;

namespace Todo.Persistence.Configurations
{
    public class TodoMConfiguration : IEntityTypeConfiguration<TodoM>
    {
        public void Configure(EntityTypeBuilder<TodoM> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.IsCompleted).HasDefaultValue(false);
        }
    }
}
