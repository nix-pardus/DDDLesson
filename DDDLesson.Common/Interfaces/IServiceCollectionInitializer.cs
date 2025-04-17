using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace DDDLesson.Common.Interfaces;

public interface IServiceCollectionInitializer
{
    public string ApplicationName { get; }
    public IServiceCollection Services { get; }
    public IConfiguration Configuration { get; }
    public IHostEnvironment Environment { get; }
    public Type[] OwnedApplicationTypes { get; }
    public Type[] LoadedTypes { get; }
    public Assembly[] Assemblies { get; }
    public IServiceCollectionInitializer AddScoped(Type typeService);
    public IServiceCollectionInitializer AddScoped(Type typeService, Type typeImplementation);
    public IServiceCollectionInitializer AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>();
    public IServiceCollectionInitializer AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>()
        where TService : class
        where TImplementation : class, TService;
}
