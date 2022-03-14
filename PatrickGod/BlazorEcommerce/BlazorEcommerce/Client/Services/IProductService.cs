﻿namespace BlazorEcommerce.Client.Services;

public interface IProductService
{
	List<Product> Products { get; set; }

	Task GetProductsAsync();

	Task<ServiceResponse<Product>> GetProductAsync(int productId);
}