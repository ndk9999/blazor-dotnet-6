using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services;

public class ProductService : IProductService
{
	private readonly HttpClient _httpClient;

	public ProductService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public event Action ProductsChanged;

	public List<Product> Products { get; set; } = new List<Product>();

	public async Task GetProductsAsync(string category = null)
	{
		var response = string.IsNullOrWhiteSpace(category)
			? await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product")
			: await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{category}");

		if (response?.Data != null)
		{
			Products = response.Data;
		}

		ProductsChanged?.Invoke();
	}

	public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
	{
		return await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
	}
}