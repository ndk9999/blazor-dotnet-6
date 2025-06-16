namespace SettingPortal.ViewModels;

public class SettingItem
{
	public string Id { get; set; }

	public string DisplayName { get; set; }

	public string SystemName { get; set; }

	public bool IsActive { get; set; }

	public string UpdatedBy { get; set; }

	public DateTime UpdatedDate { get; set; }

	public string AppId { get; set; }

	public string AppName { get; set; }
}