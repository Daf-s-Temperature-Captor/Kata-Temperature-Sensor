using DafDev.TemperatureCaptor.Domain.Sensor;
using DafDev.TemperatureCaptor.Infrastructure.InMemoryDataAccess;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddSingleton<Sensor>();
        services.AddSingleton<Context>();
        services.AddSingleton<IDisplayWeather>(x => x.GetRequiredService<Sensor>());
        services.AddSingleton<ITemperatureThresholds>(x => x.GetRequiredService<Sensor>());
        services.AddSingleton<ICaptureTemperatures, TemperatureRepository>();
        return services;
    }
}

