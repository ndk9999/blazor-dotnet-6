using Mapster;
using MapsterMapper;
using SettingPortal.Infrastrutures;
using SettingPortal.Services;

namespace SettingPortal.Extensions;

public static class ServiceExtensions
{
	public static IServiceCollection AddEntityMapper(this IServiceCollection services)
	{
		var typeConfig = TypeAdapterConfig.GlobalSettings;
		typeConfig.Scan(typeof(MapsterModule).Assembly);

		var mapperConfig = new Mapper(typeConfig);
		services.AddSingleton<IMapper>(mapperConfig);

		return services;
	}

	public static IServiceCollection AddAppServices(this IServiceCollection services)
	{
		services.AddScoped<IComputerService, ComputerService>();
		services.AddScoped<IApplicationService, ApplicationService>();
		services.AddScoped<ISettingService, SettingService>();

		return services;
	}
}