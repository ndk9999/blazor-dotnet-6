using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using SettingPortal.Data;
using SettingPortal.Extensions;
using SettingPortal.Models;

namespace SettingPortal.Services;

public interface ISettingService
{
	Task<PagedList<TOut>> SearchAsync<TOut>(
		string appId = null, string appName = null,
		int pageNumber = 1, int pageSize = 50,
		CancellationToken cancellationToken = default);

	Task<IList<AppSetting>> GetAllAsync(CancellationToken cancellationToken = default);

	Task<AppSetting> GetByIdAsync(string id, CancellationToken cancellationToken = default);

	Task<AppSetting> GetByNameAsync(
		string appIdOrName, string systemName, 
		CancellationToken cancellationToken = default);

	Task<string> GetSettingValueAsync(
		string appIdOrName, string settingName, string environment,
		CancellationToken cancellationToken = default);

	Task<bool> CreateAsync(AppSetting setting, string username, CancellationToken cancellationToken = default);

	Task<bool> UpdateAsync(AppSetting setting, string username, CancellationToken cancellationToken = default);

	Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);

	Task<bool> ToggleActiveStateAsync(string id, string username, CancellationToken cancellationToken = default);
}

public class SettingService(AppDbContext dbContext) : ISettingService
{
	public async Task<PagedList<TOut>> SearchAsync<TOut>(
		string appId = null, string appName = null, 
		int pageNumber = 1, int pageSize = 50,
		CancellationToken cancellationToken = default)
	{
		return await dbContext.Settings
			.WhereIf(appId.HasValue(), x => x.AppId == appId)
			.WhereIf(appName.HasValue(), x => x.DisplayName.Contains(appName))
			.OrderBy(x => x.DisplayName)
			.ProjectToType<TOut>()
			.ToPagedListAsync(pageNumber, pageSize, cancellationToken);
	}

	public async Task<IList<AppSetting>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await dbContext.Settings
			.OrderBy(x => x.DisplayName)
			.ToListAsync(cancellationToken);
	}

	public async Task<AppSetting> GetByIdAsync(string id, CancellationToken cancellationToken = default)
	{
		return await dbContext.Settings
			.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
	}

	public async Task<AppSetting> GetByNameAsync(string appIdOrName, string systemName, CancellationToken cancellationToken = default)
	{
		return await dbContext.Settings
			.Where(x => x.AppId == appIdOrName || x.Application.SystemName == appIdOrName.ToLower())
			.FirstOrDefaultAsync(x => x.SystemName == systemName.ToLower(), cancellationToken);
	}

	public async Task<string> GetSettingValueAsync(
		string appIdOrName, string settingName, string environment,
		CancellationToken cancellationToken = default)
	{
		var setting = await GetByNameAsync(appIdOrName, settingName, cancellationToken);

		if (setting is not {IsActive: true})
			return "{}";

		return environment?.ToLower() switch
		{
			"testing" or "t" => setting.StagingValue,
			"staging" or "s" => setting.StagingValue,
			"production" or "p" => setting.ProductionValue,
			_ => setting.DevelopmentValue
		};
	}

	public async Task<bool> CreateAsync(AppSetting setting, string username, CancellationToken cancellationToken = default)
	{
		setting.Id = Guid.NewGuid().ToString();
		setting.SystemName = setting.SystemName.ToLower();
		setting.CreatedDate = setting.UpdatedDate = DateTime.UtcNow;
		setting.CreatedBy = setting.UpdatedBy = username;

		await dbContext.Settings.AddAsync(setting, cancellationToken);
		return await dbContext.SaveChangesAsync(cancellationToken) > 0;
	}

	public async Task<bool> UpdateAsync(AppSetting setting, string username, CancellationToken cancellationToken = default)
	{
		setting.SystemName = setting.SystemName.ToLower();
		setting.UpdatedDate = DateTime.UtcNow;
		setting.UpdatedBy = username;

		dbContext.Settings.Update(setting);
		return await dbContext.SaveChangesAsync(cancellationToken) > 0;
	}

	public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
	{
		return await dbContext.Settings
			.Where(x => x.Id == id)
			.ExecuteDeleteAsync(cancellationToken) > 0;
	}

	public async Task<bool> ToggleActiveStateAsync(string id, string username, CancellationToken cancellationToken = default)
	{
		return await dbContext.Settings
			.Where(x => x.Id == id)
			.ExecuteUpdateAsync(setters => setters
				.SetProperty(x => x.IsActive, x => !x.IsActive)
				.SetProperty(x => x.UpdatedBy, username)
				.SetProperty(x => x.UpdatedDate, DateTime.UtcNow), cancellationToken) > 0;
	}
}