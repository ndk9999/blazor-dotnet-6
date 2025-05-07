using AspireProduct.Core.Entities;
using AspireProduct.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AspireProduct.DAL.Repositories;

public interface IProductRepository
{
	Task<IList<Product>> GetAllAsync(CancellationToken cancellationToken = default);
	
	ValueTask<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<bool> IsProductExistedAsync(int id, CancellationToken cancellationToken = default);

	Task<bool> AddAsync(Product product, CancellationToken cancellationToken = default);
	
	Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken = default);

	Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}

public class ProductRepository(ShopDbContext context) : IProductRepository
{
	public async Task<IList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await context.Products
			.AsNoTracking()
			.ToListAsync(cancellationToken);
	}

	public async ValueTask<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		return await context.Products.FindAsync([id], cancellationToken);
	}

	public async Task<bool> IsProductExistedAsync(int id, CancellationToken cancellationToken = default)
	{
		return await context.Products
			.AsNoTracking()
			.AnyAsync(p => p.Id == id, cancellationToken);
	}

	public async Task<bool> AddAsync(Product product, CancellationToken cancellationToken = default)
	{
		context.Products.Add(product);
		
		return await context.SaveChangesAsync(cancellationToken) > 0;
	}

	public async Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken = default)
	{
		context.Products.Update(product);

		return await context.SaveChangesAsync(cancellationToken) > 0;
	}

	public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
	{
		return await context.Products
			.Where(p => p.Id == id)
			.ExecuteDeleteAsync(cancellationToken) > 0;
	}
}