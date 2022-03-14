namespace BlazorEcommerce.Server.Data;

public class ShopContext : DbContext
{
	public ShopContext(DbContextOptions<ShopContext> options) : base(options)
	{
		
	}

	public DbSet<Category> Categories { get; set; }

	public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Category>().HasData(new[]
		{
			new Category()
			{
				Id = 1,
				Name = "Web Programming",
				Url = "web-programming"
			},
			new Category()
			{
				Id = 2,
				Name = "Software Engineering",
				Url = "software-engineering"
			},
			new Category()
			{
				Id = 3,
				Name = "Databases",
				Url = "databases"
			}
		});

		modelBuilder.Entity<Product>().HasData(new[]
		{
			new Product()
			{
				Id = 1,
				Title = "Azure SQL Revealed",
				Description = "Access detailed content and examples on Azure SQL, a set of cloud services that allows for SQL Server to be deployed in the cloud. This book teaches the fundamentals of deployment, configuration, security, performance, and availability of Azure SQL from the perspective of these same tasks and capabilities in SQL Server.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5931-3",
				Price = 26.99m,
				CategoryId = 3
			},
			new Product()
			{
				Id = 2,
				Title = "Pro ASP.NET Core 3",
				Description = "Professional developers get ready to produce leaner applications for the ASP.NET Core platform. This edition puts ASP.NET Core 3 into context, and takes a deep dive into the tools and techniques required to build modern, extensible web applications.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5440-0",
				Price = 49.99m,
				CategoryId = 1
			},
			new Product()
			{
				Id = 3,
				Title = "Design Patterns in .NET",
				Description = "Implement design patterns in .NET using the latest versions of the C# and F# languages. This book provides a comprehensive overview of the field of design patterns as they are used in today’s developer toolbox.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-4366-4",
				Price = 29.99m,
				CategoryId = 2
			},
			new Product()
			{
				Id = 4,
				Title = "Pro Angular 9",
				Description = "Welcome to this one-stop-shop for learning Angular. Pro Angular is the most concise and comprehensive guide available, giving you the knowledge you need to take full advantage of this popular framework for building your own dynamic JavaScript applications.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5998-6",
				Price = 49.99m,
				CategoryId = 1
			},
			new Product()
			{
				Id = 5,
				Title = "JavaScript Data Structures and Algorithms",
				Description = "Explore data structures and algorithm concepts and their relation to everyday JavaScript development. A basic understanding of these ideas is essential to any JavaScript developer wishing to analyze and build great software solutions.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-3988-9",
				Price = 29.99m,
				CategoryId = 2
			},
			new Product()
			{
				Id = 6,
				Title = "PostgreSQL Query Optimization",
				Description = "Write optimized queries. This book helps you write queries that perform fast and deliver results on time. You will learn that query optimization is not a dark art practiced by a small, secretive cabal of sorcerers. Any motivated professional can learn to write efficient queries from the get-go and capably optimize existing queries. You will learn to look at the process of writing a query from the database engine’s point of view, and know how to think like the database optimizer.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-6885-8",
				Price = 36.99m,
				CategoryId = 3
			},
			new Product()
			{
				Id = 7,
				Title = "MongoDB Performance Tuning",
				Description = "Use this fast and complete guide to optimize the performance of MongoDB databases and the applications that depend on them. You will be able to turbo-charge the performance of your MongoDB applications to provide a better experience for your users, reduce your running costs, and avoid application growing pains. MongoDB is the world’s most popular document database and the foundation for thousands of mission-critical applications.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-6879-7",
				Price = 29.99m,
				CategoryId = 3
			},
			new Product()
			{
				Id = 8,
				Title = "Agile Visualization with Pharo",
				Description = "Agile Visualization with Pharo focuses on the Roassal visualization engine and first presents the basic and necessary tools to visualize data, including an introduction to the Pharo programming language. Once you’ve grasped the basics, you’ll learn all about the development environment offered by Roassal. The book provides numerous ready-to-use examples.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-7161-2",
				Price = 26.99m,
				CategoryId = 2
			},
			new Product()
			{
				Id = 9,
				Title = "Programming Algorithms in Lisp",
				Description = "Programming Algorithms in Lisp shows real-world engineering considerations and constraints that influence the programs that use these algorithms. It includes practical use cases of the applications of the algorithms to a variety of real-world problems.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-6428-7",
				Price = 22.99m,
				CategoryId = 2
			},
			new Product()
			{
				Id = 10,
				Title = "Practical Svelte",
				Description = "Learn to leverage the power of Svelte to produce web applications that are efficient and fast. This project-oriented book simplifies creating sites using Svelte from start to finish, with little more than a text editor and familiar languages such as HTML, CSS, and JavaScript. It equips you with a starting toolset that you can use to develop future projects, incorporate into your existing workflow, and allow you to take your websites to the next level.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-7374-6",
				Price = 35.99m,
				CategoryId = 1
			},
			new Product()
			{
				Id = 11,
				Title = "jQuery Recipes",
				Description = "Quickly discover solutions to common problems, best practices you can follow, and everything jQuery has to offer. Using a problem-solution approach, this book begins with small initial problems that developers typically face while working with jQuery, and gradually goes deeper to explore more complex problems. The solutions include illustrations and clear, concise explanations of the code.",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-7304-3",
				Price = 15.99m,
				CategoryId = 1
			},
			new Product()
			{
				Id = 12,
				Title = "PHP 8 Solutions",
				Description = "Make your websites more dynamic by adding a feedback form, creating a private area where members can upload images that are automatically resized, or storing all your content in a database. David Powers has updated his definitive book to incorporate the latest techniques and changes to PHP with the arrival of PHP 8. New features include named attributes, constructor property promotion, the stricter and more concise match expression, union types, and more.​",
				ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-7141-4",
				Price = 39.99m,
				CategoryId = 1
			},
		});
	}
}