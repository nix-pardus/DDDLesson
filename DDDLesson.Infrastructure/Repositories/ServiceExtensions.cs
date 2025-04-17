using DDDLesson.Common.Interfaces;
using DDDLesson.Infrastructure.Repositories.WorkerRepository;
using Microsoft.Extensions.DependencyInjection;

namespace DDDLesson.Infrastructure.Repositories;

public static class ServiceExtensions
{
    public static IServiceCollection AddDbRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWorkerEntityRepository, WorkerEntityRepository>();
        return services;
    }
}
