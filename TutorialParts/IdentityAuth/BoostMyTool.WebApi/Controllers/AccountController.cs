using BoostMyTool.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoostMyTool.WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class AccountController : ControllerBase
{
	private readonly UserManager<IdentityUser> _userManager;

	public AccountController(UserManager<IdentityUser> userManager)
	{
		_userManager = userManager;
	}


	[HttpGet]
	public IActionResult Welcome()
	{
		if (User.Identity is not {IsAuthenticated: true})
		{
			return Unauthorized("You are not authenticated");
		}

		return Ok("You are authenticated");
	}

	[HttpGet("profile"), Authorize]
	public async Task<IActionResult> Profile()
	{
		var user = await _userManager.GetUserAsync(User);

		if (user == null)
		{
			return NotFound("User not found");
		}
		
		var profile = new UserProfile()
		{
			Id = user.Id,
			Name = user.UserName ?? "",
			Email = user.Email ?? "",
			PhoneNumber = user.PhoneNumber ?? ""
		};

		return Ok(profile);
	}
}