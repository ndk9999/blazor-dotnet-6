using Microsoft.EntityFrameworkCore;
using SettingPortal.Data;
using SettingPortal.Models;

namespace SettingPortal.Services;

public interface IApplicationService
{
	Task<IList<Application>> GetAllAsync(CancellationToken cancellationToken = default);

	Task<Application> GetByIdAsync(string id, CancellationToken cancellationToken = default);

	Task<Application> GetByNameAsync(string systemName, CancellationToken cancellationToken = default);

	Task<bool> CreateAsync(
		Application app, IList<string> computerList, string username,
		CancellationToken cancellationToken = default);

	Task<bool> UpdateAsync(
		Application app, IList<string> computerList, string username,
		CancellationToken cancellationToken = default);

	Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);

	Task<bool> ToggleActiveStateAsync(string id, string username, CancellationToken cancellationToken = default);
}

public class ApplicationService(AppDbContext dbContext) : IApplicationService
{
	public async Task<IList<Application>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await dbContext.Applications
			.OrderBy(x => x.DisplayName)
			.ToListAsync(cancellationToken);
	}

	public async Task<Application> GetByIdAsync(string id, CancellationToken cancellationToken = default)
	{
		return await dbContext.Applications
			.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
	}

	public async Task<Application> GetByNameAsync(string systemName, CancellationToken cancellationToken = default)
	{
		return await dbContext.Applications
			.FirstOrDefaultAsync(x => x.SystemName == systemName.ToLower(), cancellationToken);
	}

	public async Task<bool> CreateAsync(
		Application app, IList<string> computerList, string username,
		CancellationToken cancellationToken = default)
	{
		app.Id = Guid.NewGuid().ToString();
		app.SystemName = app.SystemName.ToLower();
		app.CreatedDate = app.UpdatedDate = DateTime.UtcNow;
		app.CreatedBy = app.UpdatedBy = username;

		app.AppServers = computerList
			.Select(computerId => new AppServer
			{
				Id = Guid.NewGuid().ToString(),
				AppId = app.Id,
				ComputerId = computerId,
				IsActive = true,
				CreatedDate = DateTime.UtcNow,
				CreatedBy = username,
				UpdatedDate = DateTime.UtcNow,
				UpdatedBy = username
			}).ToList();

		await dbContext.Applications.AddAsync(app, cancellationToken);
		return await dbContext.SaveChangesAsync(cancellationToken) > 0;
	}

	public async Task<bool> UpdateAsync(
		Application app, IList<string> computerList, string username,
		CancellationToken cancellationToken = default)
	{
		// Delete existing AppServers
		await dbContext.AppServers
			.Where(x => x.AppId == app.Id)
			.ExecuteDeleteAsync(cancellationToken);

		app.AppServers = computerList
			.Select(computerId => new AppServer
			{
				Id = Guid.NewGuid().ToString(),
				AppId = app.Id,
				ComputerId = computerId,
				IsActive = true,
				CreatedDate = DateTime.UtcNow,
				CreatedBy = username,
				UpdatedDate = DateTime.UtcNow,
				UpdatedBy = username
			}).ToList();

		app.SystemName = app.SystemName.ToLower();
		app.UpdatedDate = DateTime.UtcNow;
		app.UpdatedBy = username;

		dbContext.Applications.Update(app);
		return await dbContext.SaveChangesAsync(cancellationToken) > 0;
	}

	public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
	{
		// Delete existing AppServers
		await dbContext.AppServers
			.Where(x => x.AppId == id)
			.ExecuteDeleteAsync(cancellationToken);

		return await dbContext.Applications
			.Where(x => x.Id == id)
			.ExecuteDeleteAsync(cancellationToken) > 0;
	}

	public async Task<bool> ToggleActiveStateAsync(string id, string username, CancellationToken cancellationToken = default)
	{
		return await dbContext.Applications
			.Where(x => x.Id == id)
			.ExecuteUpdateAsync(setters => setters
				.SetProperty(x => x.IsActive, x => !x.IsActive)
				.SetProperty(x => x.UpdatedBy, username)
				.SetProperty(x => x.UpdatedDate, DateTime.UtcNow), cancellationToken) > 0;
	}
}