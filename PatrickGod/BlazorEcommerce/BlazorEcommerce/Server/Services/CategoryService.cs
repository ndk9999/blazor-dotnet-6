namespace BlazorEcommerce.Server.Services;

public class CategoryService : ICategoryService
{
	private readonly ShopContext _context;

	public CategoryService(ShopContext context)
	{
		_context = context;
	}


	public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
	{
		return new ServiceResponse<List<Category>>()
		{
			Data = await _context.Categories.ToListAsync()
		};
	}

	public async Task<ServiceResponse<Category>> GetCategoryByIdAsync(int categoryId)
	{
		var category = await _context.Categories.FindAsync(categoryId);

		return category == null
			? ServiceResponse<Category>.Fail("Sorry, but this category does not exist")
			: ServiceResponse<Category>.Ok(category);
	}
}