namespace BlazorEcommerce.Server.Services;

public interface IProductService
{
	Task<ServiceResponse<List<Product>>> GetProductsAsync();

	Task<ServiceResponse<Product>> GetProductByIdAsync(int productId);

	Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string category);

	Task AddProductAsync(Product product);

	Task UpdateProductAsync(Product product);

	Task DeleteProductAsync(int productId);
}