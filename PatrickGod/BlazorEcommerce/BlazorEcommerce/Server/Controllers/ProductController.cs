﻿using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;


		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
		{
			var response = await _productService.GetProductsAsync();

			return Ok(response);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int id)
		{
			var response = await _productService.GetProductByIdAsync(id);

			return Ok(response);
		}

		[HttpGet("category/{categorySlug}")]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts(string categorySlug)
		{
			var response = await _productService.GetProductsByCategoryAsync(categorySlug);

			return Ok(response);
		}
	}
}
