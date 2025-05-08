using AspireProduct.BLL.Services;
using AspireProduct.Core.Dtos;
using AspireProduct.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspireProduct.ApiService.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
	{
		var products = await productService.GetAllAsync(cancellationToken);

		return Ok(ApiResponse.Ok(products));
	}

	[HttpGet]
	[Route("{id:int}")]
	public async Task<IActionResult> GetById(int id)
	{
		var product = await productService.GetByIdAsync(id);

		if (product is null)
			return NotFound(ApiResponse.Fail<Product>("Product not found"));
		
		return Ok(ApiResponse.Ok(product));
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] Product product)
	{
		if (product is null)
			return BadRequest(ApiResponse.Fail<Product>("Product cannot be null"));

		if (!await productService.AddAsync(product))
			return BadRequest(ApiResponse.Fail<Product>("Failed to create product"));
		
		return CreatedAtAction(nameof(GetById), new { id = product.Id }, ApiResponse.Ok(product));
	}

	[HttpPut]
	[Route("{id:int}")]
	public async Task<IActionResult> Update(int id, [FromBody] Product product)
	{
		if (product is null)
			return BadRequest(ApiResponse.Fail<Product>("Product cannot be null"));

		if (product.Id != id)
			return BadRequest(ApiResponse.Fail<Product>("Product ID mismatch"));

		if (!await productService.IsProductExistedAsync(id))
			return NotFound(ApiResponse.Fail<Product>("Product not found"));

		if (!await productService.UpdateAsync(product))
			return BadRequest(ApiResponse.Fail<Product>("Failed to update product"));

		return Ok(ApiResponse.Ok(product));
	}

	[HttpDelete]
	[Route("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		if (!await productService.DeleteAsync(id))
			return NotFound(ApiResponse.Fail<Product>("Product not found"));
	
		return NoContent();
	}
}