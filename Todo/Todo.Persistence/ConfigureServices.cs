using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Common.Interfaces;
using Todo.Application.Repositories.Commands;
using Todo.Persistence.DbContext;

namespace Todo.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TodoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TodoDb"),
                builder => builder.MigrationsAssembly(typeof(TodoDbContext).Assembly.FullName)));

            services.AddScoped<ITodoDbContext>(provider => provider.GetRequiredService<TodoDbContext>());


            return services;
        }
    }
}
