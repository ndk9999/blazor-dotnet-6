using AspireProduct.BLL.Services;
using AspireProduct.DAL.Contexts;
using AspireProduct.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspireProduct.BLL;

public static class ServiceInjector
{
	public static IServiceCollection AddDataLayer(this IServiceCollection services, string connectionString)
	{
		services.AddDbContext<ShopDbContext>(options =>
			options.UseSqlServer(connectionString));

		services.AddScoped<IProductRepository, ProductRepository>();
		services.AddScoped<IAccountRepository, AccountRepository>();
		
		return services;
	}

	public static IServiceCollection AddBusinessServices(this IServiceCollection services)
	{
		services.AddScoped<IProductService, ProductService>();
		services.AddScoped<IAuthService, AuthService>();
		return services;
	}
}