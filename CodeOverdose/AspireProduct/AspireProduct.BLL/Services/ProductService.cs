using AspireProduct.Core.Entities;
using AspireProduct.DAL.Repositories;

namespace AspireProduct.BLL.Services;

public interface IProductService
{
	Task<IList<Product>> GetAllAsync(CancellationToken cancellationToken = default);

	ValueTask<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<bool> IsProductExistedAsync(int id, CancellationToken cancellationToken = default);

	Task<bool> AddAsync(Product product, CancellationToken cancellationToken = default);

	Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken = default);

	Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}

public class ProductService(IProductRepository productRepository) : IProductService
{
	public async Task<IList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await productRepository.GetAllAsync(cancellationToken);
	}

	public ValueTask<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		return productRepository.GetByIdAsync(id, cancellationToken);
	}

	public Task<bool> IsProductExistedAsync(int id, CancellationToken cancellationToken = default)
	{
		return productRepository.IsProductExistedAsync(id, cancellationToken);
	}

	public Task<bool> AddAsync(Product product, CancellationToken cancellationToken = default)
	{
		product.CreatedAt = DateTime.UtcNow;

		return productRepository.AddAsync(product, cancellationToken);
	}

	public Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken = default)
	{
		product.CreatedAt = DateTime.UtcNow;
		return productRepository.UpdateAsync(product, cancellationToken);
	}

	public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
	{
		return productRepository.DeleteAsync(id, cancellationToken);
	}
}