using AspireProduct.Core.Dtos;
using AspireProduct.Web.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace AspireProduct.Web.Components.Pages.Accounts;

public partial class Login : ComponentBase
{
	[Inject] public GenericApiClient ApiClient { get; set; }

	[Inject] public NavigationManager NavigationManager { get; set; }

	[Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }

	[Inject] public IToastService ToastService { get; set; }

	private readonly LoginRequest _loginModel = new LoginRequest();

	private async Task HandleLoginEvent()
	{
		var response = await ApiClient.PostAsync<LoginRequest, LoginResponse>("api/auth/login", _loginModel);

		if (response.Success)
		{
			await ((CustomAuthStateProvider) AuthStateProvider).MarkUserAsAuthenticatedAsync(response.Data);

			// Redirect to the home page or any other page
			NavigationManager.NavigateTo("/");
		}
		else
		{
			ToastService.ShowError(response.ErrorMessage);
		}
	}
}