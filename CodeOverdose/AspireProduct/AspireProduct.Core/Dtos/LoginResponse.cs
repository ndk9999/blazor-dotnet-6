namespace AspireProduct.Core.Dtos;

public class LoginResponse
{
	public string AccessToken { get; set; }

	public string RefreshToken { get; set; }

	public long TokenExpired { get; set; }
}