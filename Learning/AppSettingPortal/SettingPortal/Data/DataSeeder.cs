using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SettingPortal.Models;

namespace SettingPortal.Data;

public class DataSeeder(
	AppDbContext dbContext,
	UserManager<AppUser> userManager)
{
	public async Task SeedAsync()
	{
		await CreateRolesAsync();
		await CreateUsersAsync();
	}

	private async Task CreateRolesAsync()
	{
		var roles = new[]
		{
			new IdentityRole("Admin") {NormalizedName = "ADMIN"},
			new IdentityRole("Editor") {NormalizedName = "EDITOR"}
		};

		foreach (var role in roles)
		{
			if (!await dbContext.Roles.AnyAsync(r => r.Name == role.Name))
			{
				await dbContext.Roles.AddAsync(role);
			}
		}
	}

	private async Task CreateUsersAsync()
	{
		var users = new[]
		{
			new AppUser() {UserName = "phucnv", Email = "phuc.nguyen@devsoft.vn"},
			new AppUser() {UserName = "haotm", Email = "hao.tran@devsoft.vn"}
		};

		foreach (var user in users)
		{
			if (!await userManager.Users.AnyAsync(u => u.UserName == user.UserName))
			{
				var result = await userManager.CreateAsync(user, "P@ssw0rd");

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, "Admin");
				}
			}
		}
	}
}