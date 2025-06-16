using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SettingPortal.Models;

namespace SettingPortal.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
	    private string _dbPath;

	    public AppDbContext()
	    {
		    var folder = Environment.SpecialFolder.LocalApplicationData;
			var path = Environment.GetFolderPath(folder);

			_dbPath = Path.Combine(path, "SettingPortal.db");
		}

	    protected override void OnModelCreating(ModelBuilder builder)
	    {
			base.OnModelCreating(builder);

		    builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	    }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlite($"Data Source={_dbPath}");
			}

			base.OnConfiguring(optionsBuilder);
		}


		public DbSet<Computer> Computers { get; set; }

		public DbSet<Application> Applications { get; set; }

		public DbSet<AppSetting> Settings { get; set; }

		public DbSet<AppServer> AppServers { get; set; }
	}
}
