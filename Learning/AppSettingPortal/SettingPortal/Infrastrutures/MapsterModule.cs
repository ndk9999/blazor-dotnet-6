using Mapster;
using SettingPortal.Models;
using SettingPortal.ViewModels;

namespace SettingPortal.Infrastrutures;

public class MapsterModule : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.ForType<AppSetting, SettingItem>()
			.Map(dest => dest.AppName, src => src.Application.DisplayName);
	}
}