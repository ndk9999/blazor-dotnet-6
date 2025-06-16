using Microsoft.EntityFrameworkCore;
using SettingPortal.Data;
using SettingPortal.Models;

namespace SettingPortal.Services;

public interface IComputerService
{
	Task<IList<Computer>> GetAllAsync(CancellationToken cancellationToken = default);

	Task<Computer> GetByIdAsync(string id, CancellationToken cancellationToken = default);

	Task<Computer> GetByNameAsync(string systemName, CancellationToken cancellationToken = default);

	Task<bool> CreateAsync(Computer computer, string username, CancellationToken cancellationToken = default);

	Task<bool> UpdateAsync(Computer computer, string username, CancellationToken cancellationToken = default);

	Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);

	Task<bool> ToggleActiveStateAsync(string id, string username, CancellationToken cancellationToken = default);

	Task<bool> IsComputerExistedAsync(
		string id, string systemName, CancellationToken cancellationToken = default);
}

public class ComputerService(AppDbContext dbContext) : IComputerService
{
	public async Task<IList<Computer>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await dbContext.Computers
			.OrderBy(x => x.DisplayName)
			.ToListAsync(cancellationToken);
	}

	public async Task<Computer> GetByIdAsync(string id, CancellationToken cancellationToken = default)
	{
		return await dbContext.Computers
			.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
	}

	public async Task<Computer> GetByNameAsync(string systemName, CancellationToken cancellationToken = default)
	{
		return await dbContext.Computers
			.FirstOrDefaultAsync(x => x.SystemName == systemName.ToLower(), cancellationToken);
	}

	public async Task<bool> CreateAsync(Computer computer, string username, CancellationToken cancellationToken = default)
	{
		computer.Id = Guid.NewGuid().ToString();
		computer.SystemName = computer.SystemName.ToLower();
		computer.CreatedDate = computer.UpdatedDate = DateTime.UtcNow;
		computer.CreatedBy = computer.UpdatedBy = username;

		await dbContext.Computers.AddAsync(computer, cancellationToken);
		return await dbContext.SaveChangesAsync(cancellationToken) > 0;
	}

	public async Task<bool> UpdateAsync(Computer computer, string username, CancellationToken cancellationToken = default)
	{
		computer.SystemName = computer.SystemName.ToLower();
		computer.UpdatedDate = DateTime.UtcNow;
		computer.UpdatedBy = username;

		dbContext.Computers.Update(computer);
		return await dbContext.SaveChangesAsync(cancellationToken) > 0;
	}

	public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
	{
		return await dbContext.Computers
			.Where(x => x.Id == id)
			.ExecuteDeleteAsync(cancellationToken) > 0;
	}

	public async Task<bool> ToggleActiveStateAsync(string id, string username, CancellationToken cancellationToken = default)
	{
		return await dbContext.Computers
			.Where(x => x.Id == id)
			.ExecuteUpdateAsync(setters => setters
				.SetProperty(x => x.IsActive, x => !x.IsActive)
				.SetProperty(x => x.UpdatedBy, username)
				.SetProperty(x => x.UpdatedDate, DateTime.UtcNow), cancellationToken) > 0;
	}

	public async Task<bool> IsComputerExistedAsync(string id, string systemName, CancellationToken cancellationToken = default)
	{
		return await dbContext.Computers
			.AnyAsync(x => x.Id != id && x.SystemName == systemName.ToLower(), cancellationToken);
	}
}