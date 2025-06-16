using Microsoft.AspNetCore.Mvc;
using SettingPortal.Extensions;
using SettingPortal.Services;
using SettingPortal.ViewModels;

namespace SettingPortal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SettingsController : ControllerBase
{
	private readonly IComputerService _computerService;
	private readonly ISettingService _settingService;

	public SettingsController(IComputerService computerService, ISettingService settingService)
	{
		_computerService = computerService;
		_settingService = settingService;
	}


	[HttpGet]
	public async Task<IActionResult> GetAppSetting(SettingRequest model)
	{
		if (model.ClientId.IsEmpty() || !await _computerService.IsComputerExistedAsync("", model.ClientId))
			return Ok(ApiResponse.Failure("Invalid client ID"));

		if (model.ClientTime == null || model.ClientTime.Value < DateTimeOffset.UtcNow.AddMinutes(-2).ToUnixTimeSeconds())
			return Ok(ApiResponse.Failure("Bad request"));

		var settingValue = await _settingService.GetSettingValueAsync(
			model.AppName, model.SettingName, model.Environment);

		return Ok(ApiResponse.Success(settingValue));
	}
}