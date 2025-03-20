using CommunityToolkit.Maui;
using ManchesterCityJerseys.Core.Interfaces;
using ManchesterCityJerseys.Services;
using ManchesterCityJerseys.ViewModels;
using ManchesterCityJerseysApp.Services;
using ManchesterCityJerseysApp.Views;
using Microsoft.Extensions.Logging;

namespace ManchesterCityJerseysApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<IJerseyService, JerseyService>();
        builder.Services.AddSingleton<IDeviceInfoService, DeviceInfoService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();

        builder.Services.AddTransient<JerseyListViewModel>();
        builder.Services.AddTransient<JerseyItemViewModel>();
        builder.Services.AddTransient<JerseyDetailViewModel>();
        builder.Services.AddTransient<DeviceInfoViewModel>();

        builder.Services.AddTransient<JerseyListPage>();
        builder.Services.AddTransient<JerseyDetailPage>();
        builder.Services.AddTransient<DeviceInfoPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
