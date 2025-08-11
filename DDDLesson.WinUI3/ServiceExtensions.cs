using DDDLesson.Domain.PackagingTypes.GetPackagingTypesList;
using DDDLesson.Infrastructure;
using DDDLesson.WinUI3.Interfaces.Navigation;
using DDDLesson.WinUI3.Pages;
using DDDLesson.WinUI3.ViewModels;
using DDDLesson.WinUI3.ViewModels.MainPageVM;
using DDDLesson.WinUI3.ViewModels.MainPageVM.Mappings;
using DDDLesson.WinUI3.ViewModels.PackagingTypes;
using DDDLesson.WinUI3.ViewModels.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace DDDLesson.WinUI3;

public static class ServiceExtensions
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services)
    {
        services.AddInfrastructureServices();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPackagingTypesListQueryHandler).Assembly));
        
        services.AddAutoMapper(
            typeof(MainPageVMMappingProfile));

        services.AddSingleton<MainViewModel>();
        services.AddTransient<PackagingTypesViewModel>();
        services.AddTransient<WorkersViewModel>();
        services.AddTransient<MainPageViewModel>();

        services.AddTransient<MainPage>();
        services.AddTransient<PackagingTypesPage>();
        services.AddTransient<WorkersPage>();

        services.AddSingleton<INavigationService, NavigationService>();
        return services;
    }
}
