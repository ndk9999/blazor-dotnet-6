using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AspireProduct.BLL.Services;
using AspireProduct.Core.Dtos;
using AspireProduct.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace AspireProduct.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IConfiguration configuration, IAuthService authService) : ControllerBase
{
	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginRequest model)
	{
		var user = await authService.LoginAsync(model.Username, model.Password);

		if (user is not null)
		{
			var loginResponse = CreateLoginResponse(user);
			await authService.AddRefreshTokenAsync(user.Id, loginResponse.RefreshToken);

			return Ok(ApiResponse.Ok(loginResponse));
		}

		return BadRequest(ApiResponse.Fail("Invalid username or password"));
	}

	[HttpGet("refresh-token")]
	public async Task<IActionResult> RefreshToken([FromQuery] string refreshToken)
	{
		//if (string.IsNullOrEmpty(refreshToken))
		//	return BadRequest(ApiResponse.Fail("Invalid token"));

		//var principal = ValidateRefreshToken(refreshToken);

		//if (principal is null)
		//	return Unauthorized(ApiResponse.Fail("Unauthorized"));

		//var username = principal.FindFirst(ClaimTypes.Name)?.Value;

		//if (string.IsNullOrEmpty(username))
		//	return BadRequest(ApiResponse.Fail("Invalid token"));

		// TODO: Check whether the username is valid or not
		var savedToken = await authService.ValidateRefreshTokenAsync(refreshToken);

		if (savedToken is null)
			return BadRequest(ApiResponse.Fail("Invalid token"));

		var loginResponse = CreateLoginResponse(savedToken.Account);
		await authService.AddRefreshTokenAsync(savedToken.AccountId, loginResponse.RefreshToken);

		return Ok(ApiResponse.Ok(loginResponse));
	}

	private LoginResponse CreateLoginResponse(Account user)
	{
		return new LoginResponse()
		{
			AccessToken = GenerateJwtToken(user, false),
			RefreshToken = GenerateJwtToken(user, true),
			TokenExpired = DateTimeOffset.UtcNow.AddMinutes(
				configuration.GetValue<int>("Jwt:AccessTokenExpireTime")).ToUnixTimeSeconds()
		};
	}

	private ClaimsPrincipal ValidateRefreshToken(string refreshToken)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var secretKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Jwt:RefreshSecret"));

		try
		{
			var tokenValidationParameters = new TokenValidationParameters
			{
				IssuerSigningKey = new SymmetricSecurityKey(secretKey),
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = configuration.GetValue<string>("Jwt:Issuer"),
				ValidAudience = configuration.GetValue<string>("Jwt:Audience")
			};
			var principal = tokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out var validatedToken);
			
			return principal;
		}
		catch (Exception e)
		{
			return null;
		}
	}

	private string GenerateJwtToken(Account user, bool isRefreshToken)
	{
		// Define the claims for the JWT token, including the username and role
		var claims = user.UserRoles.Select(x => new Claim(ClaimTypes.Role, x.Role.Name)).ToList();
		claims.Add(new Claim(ClaimTypes.Name, user.Username));

		// Retrieve the secret key for signing the token from the configuration
		var secret = configuration.GetValue<string>(isRefreshToken ? "Jwt:RefreshSecret" : "Jwt:Secret");
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

		// Create signing credentials using the secret key and HMAC-SHA256 algorithm
		var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		// Create the JWT token with issuer, audience, claims, expiration, and signing credentials
		var token = new JwtSecurityToken(
			issuer: configuration.GetValue<string>("Jwt:Issuer"),
			audience: configuration.GetValue<string>("Jwt:Audience"),
			claims: claims,
			signingCredentials: credentials,
			expires: DateTime.UtcNow.AddMinutes(configuration.GetValue<int>(
				isRefreshToken ? "Jwt:RefreshTokenExpireTime" : "Jwt:AccessTokenExpireTime"))
		);

		// Serialize the token to a string and return it
		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}