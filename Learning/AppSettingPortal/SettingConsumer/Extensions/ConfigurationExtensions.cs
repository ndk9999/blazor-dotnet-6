using Microsoft.Extensions.Configuration;
using SettingConsumer.Providers;

namespace SettingConsumer.Extensions;

public static class ConfigurationExtensions
{
	public static IConfigurationBuilder AddApiConfiguration(
		this IConfigurationBuilder builder,
		string apiEndpoint,
		string settingName = "appsettings",
		string environment = "Development")
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
			SettingName = settingName
		};

		builder.Add(source);
		
		return builder;
	}

	public static IConfigurationBuilder AddApiConfiguration(
		this IConfigurationBuilder builder, Action<ApiConfigurationSource> configureSource)
	{
		var source = new ApiConfigurationSource();
		configureSource(source);
		builder.Add(source);

		return builder;
	}
}