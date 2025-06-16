namespace SettingConsumer.Providers;

public interface IApiConfigurationClient
{
	string GetAppSettings(string settingName, string environment);

	Task<string> GetAppSettingsAsync(string settingName, string environment, CancellationToken cancellationToken = default);
}