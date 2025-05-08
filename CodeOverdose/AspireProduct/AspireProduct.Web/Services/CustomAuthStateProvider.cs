using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AspireProduct.Core.Dtos;

namespace AspireProduct.Web.Services;

public class CustomAuthStateProvider(ProtectedLocalStorage localStorage) : AuthenticationStateProvider
{
	public const string AccessTokenKey = "access_token";
	public const string SessionStateKey = "session_state";

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		var loginResult = await localStorage.GetAsync<LoginResponse>(SessionStateKey);
		var identity = string.IsNullOrEmpty(loginResult.Value?.AccessToken) 
			? new ClaimsIdentity() 
			: GetClaimsIdentity(loginResult.Value.AccessToken);
		var principal = new ClaimsPrincipal(identity);

		return new AuthenticationState(principal);
	}

	public async Task MarkUserAsAuthenticatedAsync(LoginResponse loginResult)
	{
		await localStorage.SetAsync(SessionStateKey, loginResult);

		var authenticatedUser = new ClaimsPrincipal(GetClaimsIdentity(loginResult.AccessToken));
		var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

		NotifyAuthenticationStateChanged(authState);
	}

	public async Task MarkUserAsLoggedOutAsync()
	{
		await localStorage.DeleteAsync(SessionStateKey);

		var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
		var authState = Task.FromResult(new AuthenticationState(anonymousUser));
		
		NotifyAuthenticationStateChanged(authState);
	}

	private ClaimsIdentity GetClaimsIdentity(string token)
	{
		var handler = new JwtSecurityTokenHandler();
		var jwtToken = handler.ReadJwtToken(token);
		var claims = jwtToken.Claims.ToList();

		return new ClaimsIdentity(claims, "jwt");
	}
}