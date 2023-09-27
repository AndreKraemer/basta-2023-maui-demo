using ConferenceMauiDemo.Platforms.Windows;
using ConferenceMauiDemo.Services;
using ConferenceMauiDemo.WinUI;

namespace ConferenceMauiDemo
{
    public static class ServiceCollectionRegistrationExtension
    {
        public static void RegisterPlatformServices(this IServiceCollection services)
        {
            services.AddTransient<IDeviceInformation, WindowsDeviceInformation>();

            //services.AddTransient<IExportService, WordExportService>();
        }
    }
}
