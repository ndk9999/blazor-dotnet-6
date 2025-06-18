using Microsoft.Extensions.Configuration;
using SettingConsumer.Providers;

namespace SettingConsumer.Extensions;

public static class ConfigurationExtensions
{
	public static IConfigurationBuilder AddAppSettingsFromApi(
		this IConfigurationBuilder builder,
		string apiEndpoint,
		string settingName = "appsettings",
		string environment = null,
		Action<ApiLoadExceptionContext> exceptionHandler = null)
	{
		if (string.IsNullOrWhiteSpace(environment))
		{
#if DEBUG
			environment = "Development";
#else
			environment = "Production";
#endif
		}

		var source = new ApiConfigurationSource()
		{
			ApiEndpoint = apiEndpoint,
			Environment = environment,
			SettingName = settingName,
			OnException = exceptionHandler
		};

		builder.Add(source);
		
		return builder;
	}

	public static IConfigurationBuilder AddAppSettingsFromApi(
		this IConfigurationBuilder builder, Action<ApiConfigurationSource> configureSource)
	{
		var source = new ApiConfigurationSource()
		{
			SettingName = "appsettings",
#if DEBUG
			Environment = "Development"
#else
			Environment = "Production"
#endif
		};

		configureSource(source);
		builder.Add(source);

		return builder;
	}
}