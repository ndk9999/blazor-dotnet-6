using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly ShopContext _shopContext;


		public ProductController(ShopContext shopContext)
		{
			_shopContext = shopContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<Product>>> GetProducts()
		{
			var products = await _shopContext.Products.ToListAsync();

			return Ok(products);
		}
	}
}
