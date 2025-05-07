using AspireProduct.Core.Entities;
using AspireProduct.Web.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace AspireProduct.Web.Components.Pages.Products;

public partial class Create
{
	[Inject] public GenericApiClient ApiClient { get; set; }

	[Inject] public IToastService ToastService { get; set; }

	[Inject] public NavigationManager NavigationManager { get; set; }

	public string ErrorMessage { get; set; }

	[SupplyParameterFromForm]
	public Product ProductModel { get; set; }

	protected override Task OnInitializedAsync()
	{
		ProductModel ??= new Product();
		return base.OnInitializedAsync();
	}

	public async Task SubmitProduct()
	{
		var apiResponse = await ApiClient.PostAsync<Product, Product>("/api/products", ProductModel);
		
		if (apiResponse.Success)
		{
			ToastService.ShowSuccess("Product created successfully!");
			NavigationManager.NavigateTo("/products");
		}
		else
		{
			ToastService.ShowError(apiResponse.ErrorMessage);
			ErrorMessage = apiResponse.ErrorMessage;
		}
	}
}