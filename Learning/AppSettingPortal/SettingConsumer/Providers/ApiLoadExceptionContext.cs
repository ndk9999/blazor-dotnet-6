namespace SettingConsumer.Providers;

public class ApiLoadExceptionContext
{
	public string Environment { get; set; }

	public string SettingName { get; set; }

	public Exception Exception { get; set; }
}