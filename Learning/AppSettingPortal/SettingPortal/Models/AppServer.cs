namespace SettingPortal.Models;

public class AppServer : BaseEntity
{
	public string AppId { get; set; }

	public string ComputerId { get; set; }


	public Application Application { get; set; }

	public Computer Computer { get; set; }
}