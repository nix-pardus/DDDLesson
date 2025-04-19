using AutoMapper;
using DDDLesson.ApplicationWinUI3;
using DDDLesson.ApplicationWinUI3.Features.Workers;
using DDDLesson.ApplicationWinUI3.Features.Workers.CreateWorker;
using DDDLesson.ApplicationWinUI3.Features.Workers.DeleteWorker;
using DDDLesson.ApplicationWinUI3.Features.Workers.GetWorkersList;
using DDDLesson.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace DDDLesson.WinUI3;

public static class ServiceExtensions
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services)
    {
        services.AddDomainServices();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DomainAssemblyMarker).Assembly));

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new WorkersMappingProfile());
        });
        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddTransient<MainViewModel>();
        services.AddTransient<CreateWorkerViewModel>();
        services.AddTransient<GetWorkerListViewModel>();
        services.AddTransient<DeleteWorkerViewModel>();
        return services;
    }
}
