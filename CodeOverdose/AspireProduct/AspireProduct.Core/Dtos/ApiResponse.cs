namespace AspireProduct.Core.Dtos;

public class ApiResponse
{
	public static ApiResponse<T> Ok<T>(T data)
	{
		return new ApiResponse<T>
		{
			Success = true,
			Data = data
		};
	}

	public static ApiResponse<string> Fail(string errorMessage)
	{
		return new ApiResponse<string>
		{
			Success = false,
			ErrorMessage = errorMessage
		};
	}

	public static ApiResponse<T> Fail<T>(string errorMessage)
	{
		return new ApiResponse<T>
		{
			Success = false,
			ErrorMessage = errorMessage
		};
	}
}

public class ApiResponse<T>
{
	public bool Success { get; set; }

	public string ErrorMessage { get; set; }

	public T Data { get; set; }
}