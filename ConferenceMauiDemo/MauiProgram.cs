using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using ConferenceMauiDemo.Services;
using ConferenceMauiDemo.ViewModels;
using ConferenceMauiDemo.Views;
using Microsoft.Extensions.Logging;

namespace ConferenceMauiDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiMaps()
			.UseMauiCommunityToolkit()
			.UseMauiCommunityToolkitMarkup()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FA-6-Solid-900");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IDataService, FileDataService>();
        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddTransient<MainPage, MainPageViewModel>();
        builder.Services.AddTransient<SessionsPage, SessionsPageViewModel>();
		builder.Services.AddTransient<SessionsPageMarkup>();
        builder.Services.AddTransientWithShellRoute<SessionDetailPage, SessionDetailPageViewModel>(nameof(SessionDetailPage));
        builder.Services.AddTransient<DependencyInjectionDemoPage>();
        builder.Services.RegisterPlatformServices();

        return builder.Build();
	}
}
