using DDDLesson.Infrastructure.Persistence;
using DDDLesson.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DDDLesson.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddDbRepositories();
        return services;
    }
}
