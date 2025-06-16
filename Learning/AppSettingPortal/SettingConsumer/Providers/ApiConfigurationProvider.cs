using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace SettingConsumer.Providers;

public class ApiConfigurationProvider : ConfigurationProvider, IDisposable
{
	private readonly ApiConfigurationSource _source;
	private ApiConfigurationClient _apiClient;

	public ApiConfigurationProvider(ApiConfigurationSource source)
	{
		_source = source ?? throw new ArgumentNullException(nameof(source));
	}

	public override void Load()
	{
		try
		{
			_apiClient ??= new ApiConfigurationClient(_source.ApiEndpoint);
			
			var appSettings = _apiClient.GetAppSettings(_source.SettingName, _source.Environment);
			Load(appSettings);
		}
		catch (Exception ex)
		{
			Data = new Dictionary<string, string>();
			HandleException(ex);
		}
	}

	/// <summary>
	/// Loads the JSON data from a string.
	/// </summary>
	/// <param name="appSettings">App settings in JSON format.</param>
	private void Load(string appSettings)
	{
		try
		{
			Data = JsonConfigurationParser.Parse(appSettings);
		}
		catch (JsonException ex)
		{
			HandleException(ex);
		}
	}

	private void HandleException(Exception ex)
	{
		if (_source.OnException != null)
		{
			_source.OnException(new ApiLoadExceptionContext
			{
				Exception = ex,
				Environment = _source.Environment,
				SettingName = _source.SettingName,
			});
		}
	}

	/// <inheritdoc />
	public void Dispose() => Dispose(true);

	/// <summary>
	/// Disposes the provider.
	/// </summary>
	/// <param name="disposing"><c>true</c> if invoked from <see cref="IDisposable.Dispose"/>.</param>
	protected virtual void Dispose(bool disposing)
	{
		_apiClient?.Dispose();
		_apiClient = null;
	}

}