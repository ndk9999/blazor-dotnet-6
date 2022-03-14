namespace BlazorEcommerce.Shared;

public class ServiceResponse<T>
{
	public T? Data { get; set; }

	public bool Success { get; set; } = true;

	public string Message { get; set; } = string.Empty;


	public static ServiceResponse<T> Ok(T data)
	{
		return new ServiceResponse<T>()
		{
			Data = data
		};
	}

	public static ServiceResponse<T> Fail(string message)
	{
		return new ServiceResponse<T>()
		{
			Success = false,
			Message = message
		};
	}
}