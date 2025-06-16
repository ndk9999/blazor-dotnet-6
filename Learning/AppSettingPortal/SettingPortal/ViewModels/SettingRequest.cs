using Microsoft.AspNetCore.Mvc;

namespace SettingPortal.ViewModels;

public class SettingRequest
{
	[FromHeader(Name = "X-Client-Id")]
	public string ClientId { get; set; }

	[FromHeader(Name = "X-Client-Time")]
	public long? ClientTime { get; set; }

	[FromHeader(Name = "X-App-Name")]
	public string AppName { get; set; }

	[FromQuery(Name = "sn")]
	public string SettingName { get; set; }

	[FromQuery(Name = "env")]
	public string Environment { get; set; } = "Development";
}