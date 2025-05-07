using AspireProduct.Core.Entities;
using AspireProduct.Web.Components.Controls;
using AspireProduct.Web.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace AspireProduct.Web.Components.Pages.Products;

public partial class Index
{
	[Inject] public GenericApiClient ApiClient { get; set; }

	[Inject] public IToastService ToastService { get; set; }

	public IList<Product> Products { get; set; }

	public string ErrorMessage { get; set; }

	public Product ProductToDelete { get; set; }

	public ModalDialog ConfirmDeleteModal { get; set; }

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		await RefreshProducts();
	}

	private async Task RefreshProducts()
	{
		var apiResponse = await ApiClient.GetAsync<IList<Product>>("/api/products");
		if (apiResponse.Success)
		{
			Products = apiResponse.Data;
			ErrorMessage = null;
		}
		else
		{
			ErrorMessage = apiResponse.ErrorMessage;
		}
	}

	protected void ShowDeleteConfirmation(Product product)
	{
		ProductToDelete = product;
		ConfirmDeleteModal.Open();
	}

	protected async Task DeleteProduct()
	{
		var apiResponse = await ApiClient.DeleteAsync<Product>($"/api/products/{ProductToDelete.Id}");

		if (apiResponse.Success)
		{
			ToastService.ShowSuccess("Product deleted successfully!");
			await RefreshProducts();
		}
		else
		{
			ToastService.ShowError(apiResponse.ErrorMessage);
		}

		ConfirmDeleteModal.Close();
	}
}