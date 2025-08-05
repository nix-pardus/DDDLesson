using DDDLesson.Infrastructure.Repositories.PackagingTypeRepository;
using DDDLesson.Infrastructure.Repositories.WorkDayRepository;
using DDDLesson.Infrastructure.Repositories.WorkerRepository;
using DDDLesson.Infrastructure.Repositories.WorkUnitRepository;
using Microsoft.Extensions.DependencyInjection;

namespace DDDLesson.Infrastructure.Repositories;

public static class ServiceExtensions
{
    public static IServiceCollection AddDbRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWorkerEntityRepository, WorkerEntityRepository>();
        services.AddScoped<IPackagingTypeEntityRepository, PackagingTypeEntityRepository>();
        services.AddScoped<IWorkUnitEntityRepository, WorkUnitEntityRepository>();
        services.AddScoped<IWorkDayEntityRepository, WorkDayEntityRepository>();
        return services;
    }
}
