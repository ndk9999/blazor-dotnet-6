namespace AspireProduct.Core.Entities;

public class Account
{
	public int Id { get; set; }

	public string Username { get; set; }

	public string Password { get; set; }

	public List<AccountRole> UserRoles { get; set; } = new();
}