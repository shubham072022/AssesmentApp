using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Todo.Application.Common.Interfaces;
using Todo.Application.Repositories.Commands;
using Todo.Idenity.DbContext;
using Todo.Idenity.Repository.Commands;
using Todo.Idenity.Services;
using Todo.Idenity.Services.IServices;
using Todo.Idenity.Settings;
using Todo.Shared.Models;

namespace Todo.Idenity
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TodoIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TodoDb"),
                builder => builder.MigrationsAssembly(typeof(TodoIdentityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<TodoIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ITodoIdentityDbContext>(provider => provider.GetRequiredService<TodoIdentityDbContext>());

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

            var jwtSettings = configuration.GetSection("JWTSettings")
                .Get<JWTSettings>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience[0],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey))
                };
            });

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IAuthenticationCommandRepository, AuthenticationCommandRepository>();

            return services;
        }

    }
}
