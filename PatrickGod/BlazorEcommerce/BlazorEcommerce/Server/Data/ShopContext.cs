namespace BlazorEcommerce.Server.Data;

public class ShopContext : DbContext
{
	public ShopContext(DbContextOptions<ShopContext> options) : base(options)
	{
		
	}

	public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>().HasData(new[]
		{
			new Product()
			{
				Id = 1,
				Title = "Azure SQL Revealed",
				Description = "Access detailed content and examples on Azure SQL, a set of cloud services that allows for SQL Server to be deployed in the cloud. This book teaches the fundamentals of deployment, configuration, security, performance, and availability of Azure SQL from the perspective of these same tasks and capabilities in SQL Server.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5931-3",
				Price = 26.99m
			},
			new Product()
			{
				Id = 2,
				Title = "Pro ASP.NET Core 3",
				Description = "Professional developers get ready to produce leaner applications for the ASP.NET Core platform. This edition puts ASP.NET Core 3 into context, and takes a deep dive into the tools and techniques required to build modern, extensible web applications.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5440-0",
				Price = 49.99m
			},
			new Product()
			{
				Id = 3,
				Title = "Design Patterns in .NET",
				Description = "Implement design patterns in .NET using the latest versions of the C# and F# languages. This book provides a comprehensive overview of the field of design patterns as they are used in today’s developer toolbox.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-4366-4",
				Price = 29.99m
			},
			new Product()
			{
				Id = 4,
				Title = "Pro Angular 9",
				Description = "Welcome to this one-stop-shop for learning Angular. Pro Angular is the most concise and comprehensive guide available, giving you the knowledge you need to take full advantage of this popular framework for building your own dynamic JavaScript applications.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5998-6",
				Price = 49.99m
			},
			new Product()
			{
				Id = 5,
				Title = "JavaScript Data Structures and Algorithms",
				Description = "Explore data structures and algorithm concepts and their relation to everyday JavaScript development. A basic understanding of these ideas is essential to any JavaScript developer wishing to analyze and build great software solutions.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-3988-9",
				Price = 29.99m
			},
		});
	}
}