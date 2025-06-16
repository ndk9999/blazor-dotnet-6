namespace SettingPortal.Models;

public class Computer : BaseEntity
{
	public string DisplayName { get; set; }

	public string SystemName { get; set; }

	public string Description { get; set; }


	public List<AppServer> AppServers { get; set; }
}