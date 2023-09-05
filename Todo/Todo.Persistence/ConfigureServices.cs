using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Repositories.Commands;
using Todo.Application.Repositories.Queries;
using Todo.Application.UnitOfWork;
using Todo.Persistence.DbContext;
using Todo.Persistence.Repositories.Commands;
using Todo.Persistence.Repositories.Queries;
using Todo.Persistence.Unitofwork;

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

            services.AddScoped<ICommandUnitOfWork, CommandUnitOfWork>();
            services.AddScoped<IQueryUnitOfWork, QueryUnitOfWork>();

            services.AddScoped<ITodoCommandRepository, TodoCommandRepository>();
            services.AddScoped<ITodoQueryRepository, TodoQueryRepository>();

            return services;
        }
    }
}
