using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json.Nodes;
using Blazored.LocalStorage;
using BoostMyTool.BlazorWeb.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace BoostMyTool.BlazorWeb.Services;

public class CustomAuthStateProvider(HttpClient httpClient, ISyncLocalStorageService localStorage) : AuthenticationStateProvider
{
	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		////var identity = new ClaimsIdentity();

		//var claims = new List<Claim>()
		//{
		//	new Claim(ClaimTypes.Name, "John")
		//};
		//var identity = new ClaimsIdentity(claims, "ANY");
		//var principal = new ClaimsPrincipal(identity);

		//return Task.FromResult(new AuthenticationState(principal));


		var identity = new ClaimsIdentity();
		var principal = new ClaimsPrincipal(identity);

		try
		{
			SetupRequestHeaders();
			
			var infoResponse = await httpClient.GetAsync("manage/info");

			if (infoResponse.IsSuccessStatusCode)
			{
				var infoResult = await infoResponse.Content.ReadAsStringAsync();
				var infoObj = JsonNode.Parse(infoResult);
				var email = infoObj?["email"]?.ToString();

				identity = new ClaimsIdentity([
					new Claim(ClaimTypes.Name, email),
					new Claim(ClaimTypes.Email, email)
				], "Token");
				principal = new ClaimsPrincipal(identity);
			}
		}
		catch (Exception e)
		{
		}

		return new AuthenticationState(principal);
	}

	public async Task<ApiResponse> LoginAsync(string email, string password)
	{
		try
		{
			var response = await httpClient.PostAsJsonAsync("/login", new { email, password });

			if (response.IsSuccessStatusCode)
			{
				var loginResult = await response.Content.ReadAsStringAsync();
				var tokenObj = JsonNode.Parse(loginResult);
				var accessToken = tokenObj?["accessToken"]?.ToString();
				var refreshToken = tokenObj?["refreshToken"]?.ToString();

				localStorage.SetItem("accessToken", accessToken);
				localStorage.SetItem("refreshToken", refreshToken);

				httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

				NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

				return new ApiResponse()
				{
					Success = true
				};
			}

			return new ApiResponse()
			{
				Success = false,
				Errors = ["Invalid email or password"]
			};
		}
		catch (Exception e)
		{
			return new ApiResponse()
			{
				Success = false,
				Errors = [e.Message]
			};
		}
	}

	public void Logout()
	{
		localStorage.RemoveItem("accessToken");
		localStorage.RemoveItem("refreshToken");
		
		httpClient.DefaultRequestHeaders.Authorization = null;
		
		var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
		NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
	}

	public async Task<ApiResponse> RegisterAsync(RegisterModel model)
	{
		try
		{
			var response = await httpClient.PostAsJsonAsync("register", model);
			if (response.IsSuccessStatusCode)
			{
				return await LoginAsync(model.Email, model.Password);
			}

			var registerResult = await response.Content.ReadAsStringAsync();
			var jsonObj = JsonNode.Parse(registerResult);
			var errors = jsonObj!["errors"]?.AsObject();
			var errorList = errors!.Select(x => x.Value![0]!.ToString()).ToList();

			return new ApiResponse()
			{
				Success = false,
				Errors = errorList
			};
		}
		catch (Exception e)
		{
			return new ApiResponse()
			{
				Success = false,
				Errors = [e.Message]
			};
		}
	}

	private void SetupRequestHeaders()
	{
		var accessToken = localStorage.GetItem<string>("accessToken");

		if (!string.IsNullOrEmpty(accessToken))
		{
			httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
		}
	}
}