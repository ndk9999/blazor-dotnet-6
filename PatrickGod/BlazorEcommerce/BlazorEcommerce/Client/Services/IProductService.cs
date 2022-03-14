namespace BlazorEcommerce.Client.Services;

public interface IProductService
{
	event Action ProductsChanged;

	List<Product> Products { get; set; }

	Task GetProductsAsync(string category = null);

	Task<ServiceResponse<Product>> GetProductAsync(int productId);
}