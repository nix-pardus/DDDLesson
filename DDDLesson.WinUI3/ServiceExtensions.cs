using AutoMapper;
using DDDLesson.Domain;
using DDDLesson.Infrastructure;
using DDDLesson.WinUI3.Interfaces.Navigation;
using DDDLesson.WinUI3.Pages;
using DDDLesson.WinUI3.ViewModels;
using DDDLesson.WinUI3.ViewModels.PackagingTypes;
using DDDLesson.WinUI3.ViewModels.Workers;
using DDDLesson.WinUI3.ViewModels.Workers.CreateWorker;
using DDDLesson.WinUI3.ViewModels.Workers.DeleteWorker;
using DDDLesson.WinUI3.ViewModels.Workers.GetWorkersList;
using Microsoft.Extensions.DependencyInjection;

namespace DDDLesson.WinUI3;

public static class ServiceExtensions
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services)
    {
        services.AddInfrastructureServices();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DomainAssemblyMarker).Assembly));

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile<WorkersMappingProfile>();
            mc.AddProfile<PackagingTypesMappingProfile>();
        });
        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddSingleton<MainViewModel>();
        services.AddSingleton<CreateWorkerViewModel>();
        services.AddSingleton<GetWorkerListViewModel>();
        services.AddSingleton<DeleteWorkerViewModel>();
        services.AddSingleton<PackagingTypesViewModel>();

        services.AddTransient<MainPage>();
        services.AddTransient<PackagingTypesPage>();

        services.AddSingleton<INavigationService, NavigationService>();
        return services;
    }
}
