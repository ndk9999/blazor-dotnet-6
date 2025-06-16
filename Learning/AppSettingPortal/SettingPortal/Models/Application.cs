namespace SettingPortal.Models;

public class Application : BaseEntity
{
	/// <summary>
	/// Display name of the application, e.g., "Microsoft Word", "Google Chrome".
	/// </summary>
	public string DisplayName { get; set; }

	/// <summary>
	/// Should be assembly name.
	/// </summary>
	public string SystemName { get; set; }
	
	public string Description { get; set; }


	public List<AppServer> AppServers { get; set; }
}