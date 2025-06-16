using AlvinLaulana.HrApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlvinLaulana.HrApp.DataAccess;

public class HrDbContext : DbContext
{
	public HrDbContext(DbContextOptions<HrDbContext> options) : base(options)
	{
	}

	public DbSet<Employee> Employees { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Seed();
	}
}