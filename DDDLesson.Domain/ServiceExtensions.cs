using DDDLesson.Infrastructure.Persistence;
using DDDLesson.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DDDLesson.Domain;

public static class ServiceExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddDbRepositories();
        services.AddDbContext<AppDbContext>();
        return services;
    }
}
