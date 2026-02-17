namespace RentWheelsApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//create application services and prepare pages for dependency injection
		builder.Services.AddSingleton<SpeedyRentalShop>();
		builder.Services.AddTransient<RentalPage>();
		builder.Services.AddTransient<VehicleInventoryPage>();
		
		return builder.Build();
	}
}
