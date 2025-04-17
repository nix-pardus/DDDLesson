using AutoMapper;
using DDDLesson.ApplicationWpfLib;
using DDDLesson.ApplicationWpfLib.Features.Workers.CreateWorker;
using DDDLesson.ApplicationWpfLib.Features.Workers.GetWorkersList;
using DDDLesson.ApplicationWpfLib.ViewModels.Workers;
using DDDLesson.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace DDDLesson.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddDomainServices();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DomainAssemblyMarker).Assembly));

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new WorkersMappingProfile());
        });
        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddTransient<CreateWorkerViewModel>();
        services.AddTransient<GetWorkersListViewModel>();
        services.AddTransient<MainViewModel>();

        services.AddSingleton<MainWindow>();

        return services;
    }
}
