using ConferenceMauiDemo.Services;
using ConferenceMauiDemo.Droid;

namespace ConferenceMauiDemo;

public static class ServiceCollectionRegistrationExtension
{
    public static void RegisterPlatformServices(this IServiceCollection services)
    {
        services.AddTransient<IDeviceInformation, AndroidDeviceInformation>();
    }
}
