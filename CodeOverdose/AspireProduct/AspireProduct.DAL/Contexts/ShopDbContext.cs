using AspireProduct.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspireProduct.DAL.Contexts;

public sealed class ShopDbContext : DbContext
{
	public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
	{
		Database.EnsureCreated();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Product>()
			.HasData(new Product[]
			{
				new()
				{
					Id = 1,
					Name = "Product 1",
					Price = 10.99m,
					Quantity = 100,
					Description = "Description for Product 1",
					CreatedAt = DateTime.UtcNow
				},
				new()
				{
					Id = 2,
					Name = "Product 2",
					Price = 20.99m,
					Quantity = 200,
					Description = "Description for Product 2",
					CreatedAt = DateTime.UtcNow
				},
				new()
				{
					Id = 3,
					Name = "Product 3",
					Price = 30.99m,
					Quantity = 300,
					Description = "Description for Product 3",
					CreatedAt = DateTime.UtcNow
				},
				new()
				{
					Id = 4,
					Name = "Product 4",
					Price = 40.99m,
					Quantity = 400,
					Description = "Description for Product 4",
					CreatedAt = DateTime.UtcNow
				},
				new()
				{
					Id = 5,
					Name = "Product 5",
					Price = 15.99m,
					Quantity = 150,
					Description = "Description for Product 5",
					CreatedAt = DateTime.UtcNow
				},
				new()
				{
					Id = 6,
					Name = "Product 6",
					Price = 25.99m,
					Quantity = 250,
					Description = "Description for Product 6",
					CreatedAt = DateTime.UtcNow
				},
				new()
				{
					Id = 7,
					Name = "Product 7",
					Price = 35.99m,
					Quantity = 350,
					Description = "Description for Product 7",
					CreatedAt = DateTime.UtcNow
				},
				new()
				{
					Id = 8,
					Name = "Product 8",
					Price = 45.99m,
					Quantity = 450,
					Description = "Description for Product 8",
					CreatedAt = DateTime.UtcNow
				},
				new()
				{
					Id = 9,
					Name = "Product 9",
					Price = 55.99m,
					Quantity = 50,
					Description = "Description for Product 9",
					CreatedAt = DateTime.UtcNow
				},
				new()
				{
					Id = 10,
					Name = "Product 10",
					Price = 65.99m,
					Quantity = 60,
					Description = "Description for Product 10",
					CreatedAt = DateTime.UtcNow
				}
			});
	}

	public DbSet<Product> Products { get; set; }
}