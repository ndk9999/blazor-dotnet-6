using AspireProduct.Core.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using System;

namespace AspireProduct.Web.Services;

public class GenericApiClient(
	HttpClient httpClient, 
	ProtectedLocalStorage localStorage,
	AuthenticationStateProvider authStateProvider,
	NavigationManager navigationManager)
{
	public async Task<ApiResponse<TData>> GetAsync<TData>(string url)
	{
		try
		{
			await SetupRequestHeaders();
			return await httpClient.GetFromJsonAsync<ApiResponse<TData>>(url);
		}
		catch (Exception e)
		{
			return ApiResponse.Fail<TData>(e.Message);
		}
	}

	public async Task<ApiResponse<TData>> PostAsync<TPayload, TData>(string url, TPayload data)
	{
		try
		{
			await SetupRequestHeaders();

			var response = await httpClient.PostAsJsonAsync(url, data);
			var responseData = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode && string.IsNullOrWhiteSpace(responseData))
			{
				return ApiResponse.Fail<TData>(response.ReasonPhrase);
			}

			return JsonConvert.DeserializeObject<ApiResponse<TData>>(responseData);
		}
		catch (Exception e)
		{
			return ApiResponse.Fail<TData>(e.Message);
		}
	}

	public async Task<ApiResponse<TData>> PutAsync<TPayload, TData>(string url, TPayload data)
	{
		try
		{
			await SetupRequestHeaders();

			var response = await httpClient.PutAsJsonAsync(url, data);
			var responseData = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode && string.IsNullOrWhiteSpace(responseData))
			{
				return ApiResponse.Fail<TData>(response.ReasonPhrase);
			}

			return JsonConvert.DeserializeObject<ApiResponse<TData>>(responseData);
		}
		catch (Exception e)
		{
			return ApiResponse.Fail<TData>(e.Message);
		}
	}

	public async Task<ApiResponse<TData>> DeleteAsync<TData>(string url)
	{
		try
		{
			await SetupRequestHeaders();

			var response = await httpClient.DeleteAsync(url);
			var responseData = await response.Content.ReadAsStringAsync();

			return string.IsNullOrWhiteSpace(responseData)
				? ApiResponse.Ok<TData>(default)
				: JsonConvert.DeserializeObject<ApiResponse<TData>>(responseData);
		}
		catch (Exception e)
		{
			return ApiResponse.Fail<TData>(e.Message);
		}
	}

	private async Task SetupRequestHeaders()
	{
		var loginResult = await localStorage.GetAsync<LoginResponse>(CustomAuthStateProvider.SessionStateKey);
		var sessionState = loginResult.Value;
		var accessToken = "";

		if (sessionState != null && !string.IsNullOrWhiteSpace(sessionState.AccessToken))
		{
			if (sessionState.TokenExpired < DateTimeOffset.UtcNow.ToUnixTimeSeconds())
			{
				// Handle token expiration (e.g., refresh token or redirect to login page)
				await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOutAsync();
				//navigationManager.NavigateTo("/login");
			}
			else if (sessionState.TokenExpired < DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds())
			{
				var refreshResult = await RefreshTokenAsync(sessionState.RefreshToken);
				if (refreshResult != null)
				{
					await ((CustomAuthStateProvider)authStateProvider).MarkUserAsAuthenticatedAsync(refreshResult);
					accessToken = refreshResult.AccessToken;
				}
				else
				{
					await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOutAsync();
					//navigationManager.NavigateTo("/login");
				}
			}
			else
			{
				accessToken = sessionState.AccessToken;
			}
		}

		if (!string.IsNullOrWhiteSpace(accessToken))
		{
			httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
		}
	}

	private async Task<LoginResponse> RefreshTokenAsync(string refreshToken)
	{
		try
		{
			var response = await httpClient.GetAsync($"/api/auth/refresh-token?refreshToken={refreshToken}");
			
			if (!response.IsSuccessStatusCode) return null;

			var responseData = await response.Content.ReadAsStringAsync();

			if (string.IsNullOrWhiteSpace(responseData)) return null;

			var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoginResponse>>(responseData);

			return apiResponse.Success ? apiResponse.Data : null;
		}
		catch (Exception e)
		{
			return null;
		}
	}
}