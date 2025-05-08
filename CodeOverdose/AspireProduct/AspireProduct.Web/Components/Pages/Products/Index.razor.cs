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

	private IList<Product> _products;

	private string _errorMessage;

	private Product _productToDelete;

	private ModalDialog _confirmDeleteModal;

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
			_products = apiResponse.Data;
			_errorMessage = null;
		}
		else
		{
			_errorMessage = apiResponse.ErrorMessage;
		}
	}

	protected void ShowDeleteConfirmation(Product product)
	{
		_productToDelete = product;
		_confirmDeleteModal.Open();
	}

	protected async Task DeleteProduct()
	{
		var apiResponse = await ApiClient.DeleteAsync<Product>($"/api/products/{_productToDelete.Id}");

		if (apiResponse.Success)
		{
			ToastService.ShowSuccess("Product deleted successfully!");
			await RefreshProducts();
		}
		else
		{
			ToastService.ShowError(apiResponse.ErrorMessage);
		}

		_confirmDeleteModal.Close();
	}
}