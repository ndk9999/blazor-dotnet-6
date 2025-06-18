using Microsoft.Extensions.Configuration;
using SettingConsumer.Models;
using System.Net.Http.Json;
using System.Reflection;

namespace SettingConsumer.Providers;

public class ApiConfigurationClient : IApiConfigurationClient, IDisposable
{
	private HttpClient _client;
	private readonly string _apiEndpoint;

	public ApiConfigurationClient(IConfiguration configuration)
	{
		ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

		_apiEndpoint = configuration["ApiEndpoints:Settings"] ?? throw new Exception("Setting API endpoint is missing");
		InitializeClient();
	}

	internal ApiConfigurationClient(string apiEndpoint)
	{
		_apiEndpoint = apiEndpoint ?? throw new ArgumentNullException(nameof(apiEndpoint));
		InitializeClient();
	}

	private void InitializeClient()
	{
		if (_client != null) return;

		_client = new HttpClient();
		_client.DefaultRequestHeaders.Add("X-Client-Id", GetClientId());
		_client.DefaultRequestHeaders.Add("X-App-Name", GetAppName());
	}

	public string GetAppSettings(string settingName, string environment)
	{
		return GetAppSettingsAsync(settingName, environment).GetAwaiter().GetResult();
	}

	public async Task<string> GetAppSettingsAsync(string settingName, string environment, CancellationToken cancellationToken = default)
	{
		_client.DefaultRequestHeaders.Add("X-Client-Time", DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString());

		var endpoint = new Uri($"{_apiEndpoint}?sn={settingName}&env={environment}");
		var response = await _client.GetFromJsonAsync<ApiResponse<string>>(endpoint, cancellationToken);

		if (response is not { IsSuccess: true })
		{
			var errors = response?.Errors ?? new List<string> { "Unknown error occurred." };
			throw new InvalidOperationException($"Bad API request: {string.Join(", ", errors)}");
		}

		return response.Data ?? "{}";
	}

	private static string GetClientId()
	{
		return Environment.MachineName;
	}

	private static string GetAppName()
	{
		return Assembly.GetExecutingAssembly().GetName().Name
		       ?? throw new InvalidOperationException("App name could not be determined from the executing assembly.");
	}

	public void Dispose() => Dispose(true);

	private void Dispose(bool disposing)
	{
		_client?.Dispose();
		_client = null;
	}
}