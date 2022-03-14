namespace BlazorEcommerce.Client.Services;

public interface ICategoryService
{
	List<Category> Categories { get; set; }

	Task GetCategoriesAsync();
}