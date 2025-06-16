using Microsoft.Extensions.Configuration;

namespace SettingConsumer.Providers;

public class ApiConfigurationSource : IConfigurationSource
{
	public string ApiEndpoint { get; set; }

	public string Environment { get; set; }

	public string SettingName { get; set; }

	public Action<ApiLoadExceptionContext> OnException { get; set; }

	public IConfigurationProvider Build(IConfigurationBuilder builder)
	{
		return new ApiConfigurationProvider(this);
	}
}