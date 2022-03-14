namespace BlazorEcommerce.Server.Services;

public interface IProductService
{
	Task<ServiceResponse<List<Product>>> GetProductsAsync();

	Task<ServiceResponse<Product>> GetProductByIdAsync(int productId);

	Task AddProductAsync(Product product);

	Task UpdateProductAsync(Product product);

	Task DeleteProductAsync(int productId);
}