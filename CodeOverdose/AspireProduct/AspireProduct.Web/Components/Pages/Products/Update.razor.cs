using AspireProduct.Core.Entities;
using AspireProduct.Web.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace AspireProduct.Web.Components.Pages.Products;

public partial class Update : ComponentBase
{
	[Inject] public GenericApiClient ApiClient { get; set; }

	[Inject] public NavigationManager NavigationManager { get; set; }

	[Inject] public IToastService ToastService { get; set; }

	[Parameter] public int Id { get; set; }

	public string ErrorMessage { get; set; }

	[SupplyParameterFromForm] 
	public Product ProductModel { get; set; } = new Product();

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		var apiResponse = await ApiClient.GetAsync<Product>($"/api/products/{Id}");
		
		if (apiResponse.Success)
		{
			ProductModel = apiResponse.Data;
		}
		else
		{
			ToastService.ShowError(apiResponse.ErrorMessage);
			NavigationManager.NavigateTo("/products");
		}
	}

	public async Task SubmitProduct()
	{
		var apiResponse = await ApiClient.PutAsync<Product, Product>($"/api/products/{Id}", ProductModel);

		if (apiResponse.Success)
		{
			ToastService.ShowSuccess("Product updated successfully!");
			NavigationManager.NavigateTo("/products");
		}
		else
		{
			ToastService.ShowError(apiResponse.ErrorMessage);
			ErrorMessage = apiResponse.ErrorMessage;
		}
	}
}