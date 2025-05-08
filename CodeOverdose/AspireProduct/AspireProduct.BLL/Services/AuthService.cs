using AspireProduct.Core.Entities;
using AspireProduct.DAL.Repositories;

namespace AspireProduct.BLL.Services;

public interface IAuthService
{
	Task<Account> LoginAsync(string username, string password, CancellationToken cancellationToken = default);

	Task<bool> AddRefreshTokenAsync(int userId, string refreshToken, CancellationToken cancellationToken = default);

	Task<RefreshToken> ValidateRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
}

public class AuthService(IAccountRepository userRepository) : IAuthService
{
	public async Task<Account> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
	{
		var user = await userRepository.GetByUserNameAsync(username, cancellationToken);
		return user?.Password == password ? user : null;
	}

	public async Task<bool> AddRefreshTokenAsync(int userId, string refreshToken, CancellationToken cancellationToken = default)
	{
		await userRepository.RemoveRefreshTokensAsync(userId, cancellationToken);

		var tokenEntity = new RefreshToken
		{
			AccountId = userId,
			Token = refreshToken,
			CreatedAt = DateTime.UtcNow
		};

		return await userRepository.AddRefreshTokenAsync(tokenEntity, cancellationToken);
	}

	public async Task<RefreshToken> ValidateRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
	{
		return string.IsNullOrWhiteSpace(refreshToken)
			? null
			: await userRepository.GetRefreshTokenAsync(refreshToken, cancellationToken);
	}
}