using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcommerce.Shared;

public class Product
{
	public int Id { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal Price { get; set; }

	public string ImageUrl { get; set; }

}