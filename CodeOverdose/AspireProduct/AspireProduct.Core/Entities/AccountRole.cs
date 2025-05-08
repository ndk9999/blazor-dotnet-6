namespace AspireProduct.Core.Entities;

public class AccountRole
{
	public int Id { get; set; }

	public int AccountId { get; set; }

	public int RoleId { get; set; }

	public Account Account { get; set; }

	public JobRole Role { get; set; }
}