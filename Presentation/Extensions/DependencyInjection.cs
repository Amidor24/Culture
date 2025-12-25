using Application.Commands;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCleanArchitectureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DatabaseSchema"),
                sqlOptions => sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
            );

            services.AddScoped<IRepository, Repository>();

            services.AddMediatR(typeof(Create).Assembly);

            return services;
        }
    }
}
