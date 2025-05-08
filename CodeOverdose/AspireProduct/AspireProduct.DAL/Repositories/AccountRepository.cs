using AspireProduct.Core.Entities;
using AspireProduct.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AspireProduct.DAL.Repositories;

public interface IAccountRepository
{
	Task<Account> GetByUserNameAsync(string username, CancellationToken cancellationToken = default);

	Task<RefreshToken> GetRefreshTokenAsync(string token, CancellationToken cancellationToken = default);

	Task<bool> AddRefreshTokenAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default);

	Task<bool> RemoveRefreshTokensAsync(int userId, CancellationToken cancellationToken = default);
}

public class AccountRepository(ShopDbContext dbContext) : IAccountRepository
{
	public async Task<Account> GetByUserNameAsync(string username, CancellationToken cancellationToken = default)
	{
		return await dbContext.Accounts
			.Include(a => a.UserRoles)
			.ThenInclude(a => a.Role)
			.FirstOrDefaultAsync(a => a.Username == username, cancellationToken);
	}

	public async Task<RefreshToken> GetRefreshTokenAsync(string token, CancellationToken cancellationToken = default)
	{
		return await dbContext.RefreshTokens
			.Include(t => t.Account)
			.ThenInclude(a => a.UserRoles)
			.ThenInclude(r => r.Role)
			.FirstOrDefaultAsync(t => t.Token == token, cancellationToken);
	}

	public async Task<bool> AddRefreshTokenAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default)
	{
		await dbContext.RefreshTokens.AddAsync(refreshToken, cancellationToken);
		return await dbContext.SaveChangesAsync(cancellationToken) > 0;
	}

	public async Task<bool> RemoveRefreshTokensAsync(int userId, CancellationToken cancellationToken = default)
	{
		return await dbContext.RefreshTokens
			.Where(t => t.AccountId == userId)
			.ExecuteDeleteAsync(cancellationToken) > 0;
	}
}