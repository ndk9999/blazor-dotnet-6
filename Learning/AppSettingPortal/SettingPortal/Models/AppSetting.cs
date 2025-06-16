namespace SettingPortal.Models;

public class AppSetting : BaseEntity
{
	public string DisplayName { get; set; }

	public string SystemName { get; set; }

	public string Description { get; set; }

	public string DevelopmentValue { get; set; } = "{}";

	public string TestingValue { get; set; } = "{}";

	public string StagingValue { get; set; } = "{}";

	public string ProductionValue { get; set; } = "{}";

	public string AppId { get; set; }

	public Application Application { get; set; }
}