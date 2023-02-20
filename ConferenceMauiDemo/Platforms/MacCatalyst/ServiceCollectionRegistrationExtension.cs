using ConferenceMauiDemo.Services;
using ConferenceMauiDemo.MacCatalyst;

namespace ConferenceMauiDemo
{
    public static class ServiceCollectionRegistrationExtension
    {
        public static void RegisterPlatformServices(this IServiceCollection services)
        {
            services.AddTransient<IDeviceInformation, MacCatalystDeviceInformation>();
        }
    }
}
