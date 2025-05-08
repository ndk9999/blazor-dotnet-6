namespace AspireProduct.Core.Entities;

public class RefreshToken
{
	public int Id { get; set; }

	public string Token { get; set; }

	public DateTime CreatedAt { get; set; }

	public int AccountId { get; set; }

	public Account Account { get; set; }
}