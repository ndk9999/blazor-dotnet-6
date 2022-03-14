namespace BlazorEcommerce.Server.Services;

public class ProductService : IProductService
{
	private readonly ShopContext _context;


	public ProductService(ShopContext context)
	{
		_context = context;
	}

	public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
	{
		return new ServiceResponse<List<Product>>()
		{
			Data = await _context.Products.ToListAsync()
		};
	}

	public async Task<ServiceResponse<Product>> GetProductByIdAsync(int productId)
	{
		var product = await _context.Products.FindAsync(productId);

		return product == null
			? ServiceResponse<Product>.Fail("Sorry, but this product does not exist")
			: ServiceResponse<Product>.Ok(product);
	}

	public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string category)
	{
		return new ServiceResponse<List<Product>>()
		{
			Data = await _context.Products.Where(p => p.Category.Url == category).ToListAsync()
		};
	}

	public Task AddProductAsync(Product product)
	{
		throw new NotImplementedException();
	}

	public Task UpdateProductAsync(Product product)
	{
		throw new NotImplementedException();
	}

	public Task DeleteProductAsync(int productId)
	{
		throw new NotImplementedException();
	}
}